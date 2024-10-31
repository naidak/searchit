using Azure.Core;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Helper.Services;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.ViewModels;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using JobSearchingWebApp.Endpoints.Kandidat.Dodaj;
using JobSearchingWebApp.Endpoints.Kompanija.Dodaj;
using Microsoft.Identity.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.WebUtilities;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity.UI.Services;
using JobSearchingWebApp.Data;

namespace JobSearchingWebApp.Endpoints.Autentifikacija
{
    [Route("")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Database.Korisnik> userManager;
        private readonly SignInManager<Database.Korisnik> signInManager;
        private readonly IMapper mapper;
        private readonly IConfiguration config;
        private readonly JWTService jwtService; 
        private readonly EmailService emailService;
        private readonly SmsService smsService;
        private readonly ApplicationDbContext dbContext;

        public AuthController(UserManager<Database.Korisnik> userManager,
                              SignInManager<Database.Korisnik> signInManager,
                              IMapper mapper, IConfiguration config,
                              JWTService jwtService,
                              EmailService emailService,
                              SmsService smsService, 
                              ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.config = config;
            this.jwtService = jwtService;
            this.emailService = emailService;
            this.smsService = smsService;
            this.dbContext = dbContext;
        }

        [HttpPost("register/admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegistracijaRequest request)
        {
            return await RegisterUser<Administrator, RegistracijaRequest>(request, "Admin", 1);
        }

        [HttpPost("register/kandidat")]
        public async Task<IActionResult> RegisterKandidat([FromBody] KandidatDodajRequest request)
        {
            return await RegisterUser<Database.Kandidat, KandidatDodajRequest>(request, "Kandidat", 2);
        }

        [HttpPost("register/kompanija")]
        public async Task<IActionResult> RegisterKompanija([FromBody] KompanijaDodajRequest request)
        {
            var user = mapper.Map<Database.Kompanija>(request);
            user.PasswordSalt = HelperMethods.GenerateSalt();
            user.UlogaId = 3;

            byte[] logoBytes = null;
            if (!string.IsNullOrEmpty(request.Logo))
            {
                // Convert base64 string to byte array
                var base64Data = Regex.Replace(request.Logo, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);
                logoBytes = Convert.FromBase64String(base64Data);
            }

            user.Logo = logoBytes;

            var lokacija = dbContext.Lokacija.Where(x => x.Naziv == request.Lokacija).FirstOrDefault();

            if (lokacija != null)
            {
                user.Lokacija = lokacija;
            }

            else
            {
                var novaLokacija = new Database.Lokacija()
                {
                    Naziv = request.Lokacija
                };

                await dbContext.Lokacija.AddAsync(novaLokacija);
                await dbContext.SaveChangesAsync();

                var nova = await dbContext.Lokacija.Where(x => x.Naziv == request.Lokacija).FirstOrDefaultAsync();

                if (nova != null)
                {
                    user.Lokacija = nova;
                }
            }

            var result = await userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await userManager.AddToRoleAsync(user, "Kompanija");

            try
            {
                if (await SendConfirmEMailAsync(user))
                {
                    return Ok(new JsonResult(new { title = "Account Created", message = "Your account has been created, please confirm your email address." }));
                }

                return BadRequest("Failed to send email. Please contact admin");
            }
            catch (Exception)
            {
                return BadRequest("Failed to send email. Please contact admin");
            }
        }

        [HttpPut("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmail model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null || user.IsObrisan == true) 
                return Unauthorized(new { message = "This email address has not been registered yet" } );

            if (user.EmailConfirmed == true) 
                return BadRequest(new { message = "Your email was confirmed before. Please login to your account" });

            try
            {
                var decodedTokenBytes = WebEncoders.Base64UrlDecode(model.Token);
                var decodedToken = Encoding.UTF8.GetString(decodedTokenBytes);

                var result = await userManager.ConfirmEmailAsync(user, decodedToken);
                if (result.Succeeded)
                { 
                    return Ok(new JsonResult(new { title = "Email confirmed", message = "Your email address is confirmed. You can login now" }));
                }

                return BadRequest("Invalid token. Please try again");
            }
            catch (Exception)
            {
                return BadRequest("Invalid token. Please try again");
            }
        }

        [HttpPost("resend-email-confirmation-link/{email}")]
        public async Task<IActionResult> ResendEMailConfirmationLink(string email)
        {
            if (string.IsNullOrEmpty(email)) return BadRequest("Invalid email");
            var user = await userManager.FindByEmailAsync(email);

            if (user == null || user.IsObrisan) return Unauthorized("This email address has not been registerd yet");
            if (user.EmailConfirmed == true) return BadRequest("Your email address was confirmed before. Please login to your account");

            try
            {
                if (await SendConfirmEMailAsync(user))
                {
                    return Ok(new JsonResult(new { title = "Confirmation link sent", message = "Please confirm your email address" }));
                }

                return BadRequest("Failed to send email. PLease contact admin");
            }
            catch (Exception)
            {
                return BadRequest("Failed to send email. PLease contact admin");
            }
        }

        [Authorize]
        [HttpGet("refresh-token")]
        public async Task<ActionResult<AuthResponse>> RefereshToken()
        {
            var user = await userManager.FindByEmailAsync(User.FindFirst(ClaimTypes.Email)?.Value);

            var role = await userManager.GetRolesAsync(user);
            string roleString = string.Join(", ", role);

            return new AuthResponse { JWT = await jwtService.CreateJWT(user), Id = user.Id, Role = roleString};
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest model)
        {
            var user = await userManager.FindByNameAsync(model.Username);

            if (user == null || user.IsObrisan == true) return Unauthorized(new { message = "Invalid username or password" });
            if (user.EmailConfirmed == false) return Unauthorized(new { message = "Please confirm your email." });

            if (user.TwoFactorEnabled)
            {
                var TwoFactorAuthenticationToken = await userManager.GenerateTwoFactorTokenAsync(user, "Email");

                if (user.PhoneNumberConfirmed && user.UlogaId == 2)
                { 
                    //Sending SMS 
                    await smsService.SendSmsAsync(user.PhoneNumber, $"Your 2FA Token is {TwoFactorAuthenticationToken}");
                }   
                
                //Sending Email
                var emailSend = new EmailSend(user.Email, "2FA Token", $"Your 2FA Token is {TwoFactorAuthenticationToken}");
                await emailService.SendEmailAsync(emailSend);

                return BadRequest(new { message = "RequiresTwoFactor" });
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }

            await userManager.ResetAccessFailedCountAsync(user);
            await userManager.SetLockoutEndDateAsync(user, null);

            var role = await userManager.GetRolesAsync(user);
            string roleString = string.Join(", ", role);


            return new AuthResponse { JWT = await jwtService.CreateJWT(user), Id = user.Id, Role = roleString };
        }

        private async Task<IActionResult> RegisterUser<TUser, TRequest>(TRequest request, string role, int roleId)
             where TUser : Database.Korisnik, new()
             where TRequest : IUserRegistrationRequest
        {
            var user = mapper.Map<TUser>(request);
            user.PasswordSalt = HelperMethods.GenerateSalt();
            user.UlogaId = roleId;

            var result = await userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await userManager.AddToRoleAsync(user, role);

            try
            {
                if (await SendConfirmEMailAsync(user))
                {
                    return Ok(new JsonResult(new { title = "Account Created", message = "Your account has been created, please confirm your email address." }));
                }

                return BadRequest("Failed to send email. Please contact admin");
            }
            catch (Exception)
            {
                return BadRequest("Failed to send email. Please contact admin");
            }
        }

        private async Task<bool> SendConfirmEMailAsync(Database.Korisnik user)
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var url = $"{config["JwtSettings:Audience"]}/{config["Email:ConfirmEmailPath"]}?token={token}&email={user.Email}";

            var body = $"<p>Hello</p>" +
                "<p>Please confirm your email address by clicking on the following link.</p>" +
                $"<p><a href=\"{url}\">Click here</a></p>" +
                "<p>Thank you,</p>" +
                $"<br>{config["Email:ApplicationName"]}";

            var emailSend = new EmailSend(user.Email, "Confirm your email", body);

            return await emailService.SendEmailAsync(emailSend);
        }

        [Authorize(Roles = "Kandidat")]
        [HttpPost("send-phone-verification-code/{kandidatId}")]
        public async Task<IActionResult> SendPhoneVerificationCode(string kandidatId)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.FindByIdAsync(userId);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            if(userId == kandidatId && user.PhoneNumber != null)
            {
                var token = await userManager.GenerateChangePhoneNumberTokenAsync(user, user.PhoneNumber);

                var result = await smsService.SendSmsAsync(user.PhoneNumber, token);

                if (result)
                {
                    return Ok(new { Message = "Verification code has been sent." });
                }
                else
                {
                    return BadRequest();
                }
            }

            else return Unauthorized(); 
        }


        [Authorize(Roles = "Kandidat")]
        [HttpPost("verify-phone-number/{token}")]
        public async Task<IActionResult> VerifyPhoneNumber(string token)
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }

            var PhoneNumber = user.PhoneNumber;

            var result = await userManager.VerifyChangePhoneNumberTokenAsync(user, token, PhoneNumber);

            if (result)
            {
                user.PhoneNumberConfirmed = true;
                await userManager.UpdateAsync(user);

                return Ok(new { Message = "Phone number has been succefully verified."});
            }
            else
            {
                return BadRequest(new { Message = "Error, please try again." });
            }
        }


        [Authorize]
        [HttpGet("manage-two-factor-authentication")]
        public async Task<IActionResult> ManageTwoFactorAuthentication()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound(new { message = $"Unable to load user with ID '{userManager.GetUserId(User)}'." });
            }

            if (!user.PhoneNumberConfirmed && user.UlogaId == 2)
            {
                return BadRequest(new { message = "Your phone number has not beed confirmed yet." });
            }

            string Message;

            if (user.TwoFactorEnabled)
            {
                Message = "Disable 2FA";
            }
            else
            {
                Message = "Enable 2FA";
            }

            //Generate the Two Factor Authentication Token
            var TwoFactorToken = await userManager.GenerateTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider);

            if (user.PhoneNumberConfirmed && user.UlogaId == 2 && user.PhoneNumber != null)
            {
                //Sending SMS
                await smsService.SendSmsAsync(user.PhoneNumber, $"Your Token to {Message} is {TwoFactorToken}");
            }

            if (user.Email != null)
            {
                //Sending Email
                var emailSend = new EmailSend(user.Email, Message, $"Your Token to {Message} is {TwoFactorToken}");
                await emailService.SendEmailAsync(emailSend);

            }

            return Ok(new { message = "Verification code has been sent." }); 
        }


        [Authorize]
        [HttpPost("manage-two-factor-authentication/{token}")]
        public async Task<IActionResult> ManageTwoFactorAuthentication(string token)
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound(new { message = $"Unable to load user with ID '{userManager.GetUserId(User)}'." });
            }

            var result = await userManager.VerifyTwoFactorTokenAsync(user, TokenOptions.DefaultPhoneProvider, token);

            if (result)
            {
                var message = ""; 

                if (user.TwoFactorEnabled)
                {
                    user.TwoFactorEnabled = false;
                    message = "You have Sucessfully Disabled Two Factor Authentication";
                }
                else
                {
                    user.TwoFactorEnabled = true;
                    message = "You have Sucessfully Enabled Two Factor Authentication";
                }

                await userManager.UpdateAsync(user);

                return Ok(new { message = message });
            }
            else
            { 
                return BadRequest(new { message = "Unable to Enable/Disable Two Factor Authentication" });
            }
        }


        [AllowAnonymous]
        [HttpPost("verify-two-factor")]
        public async Task<ActionResult<AuthResponse>> VerifyTwoFactor(VerifyTwoFactorToken model)
        {
            var user = await userManager.FindByNameAsync(model.Username);

            if (user == null || user.IsObrisan == true)
            {
                return NotFound(new { message = $"Unable to load user with username '{model.Username}'." });
            }

            var result = await userManager.VerifyTwoFactorTokenAsync(user, "Email", model.Token);

            if (result)
            {
                await userManager.ResetAccessFailedCountAsync(user);
                await userManager.SetLockoutEndDateAsync(user, null);

                var role = await userManager.GetRolesAsync(user);
                string roleString = string.Join(", ", role);


                return new AuthResponse { JWT = await jwtService.CreateJWT(user), Id = user.Id, Role = roleString };
            }

            return Unauthorized("Invalid 2FA code.");
        }
    }
}
