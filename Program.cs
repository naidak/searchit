
using IdentityServer3.Core.Services;
using JobSearchingWebApp.Data;
using JobSearchingWebApp.Helper;
using JobSearchingWebApp.Helper.Services;
using JobSearchingWebApp.Database;
using JobSearchingWebApp.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Mapster;
using JobSearchingWebApp.Endpoints.Kompanija.Dodaj;
using JobSearchingWebApp.Endpoints.Kompanija.GetById;
using System.Text.Json.Serialization;
using JobSearchingWebApp.Endpoints.Kompanija.Update;
using DotNetEnv;
 
// Load environment variables from the .env file
Env.Load();

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .AddEnvironmentVariables()
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddConfiguration(config);

TypeAdapterConfig<KompanijaDodajRequest, Kompanija>.NewConfig()
    .Ignore(dest => dest.Logo)
    .Ignore(kompanija => kompanija.Lokacija);

TypeAdapterConfig<KompanijaGetByIdResponse, Kompanija>.NewConfig()
    .Ignore(dest => dest.Logo);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("db_local")), ServiceLifetime.Scoped);

// Add services to the container.

builder.Services.AddIdentityCore<Korisnik>()
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>() 
    .AddEntityFrameworkStores<ApplicationDbContext>() 
    .AddSignInManager<SignInManager<Korisnik>>() 
    .AddUserManager<UserManager<Korisnik>>() 
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultPhoneProvider;
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])),
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidateIssuer = true,
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "searchit API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\nEnter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped<JWTService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<SmsService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMapster();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
    options => options
        .SetIsOriginAllowed(x => _ = true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
); //This needs to set everything allowed


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
