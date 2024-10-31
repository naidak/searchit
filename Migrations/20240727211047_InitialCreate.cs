using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearchingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpisProfila = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iskustvo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iskustvo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jezici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jezici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifikacije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vrsta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpisiKompanija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpisPoslovanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojOtvorenihPozicija = table.Column<int>(type: "int", nullable: false),
                    BrojZaposlenika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpisiKompanija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tehnologije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tehnologije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uloge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vjestine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vjestine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RadnoIskustvo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivPozicija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumPocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NazivKompanije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadnoIskustvo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadnoIskustvo_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CVJezici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    JezikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVJezici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVJezici_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVJezici_Jezici_JezikId",
                        column: x => x.JezikId,
                        principalTable: "Jezici",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CVTehnologije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    TehnologijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVTehnologije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVTehnologije_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVTehnologije_Tehnologije_TehnologijaId",
                        column: x => x.TehnologijaId,
                        principalTable: "Tehnologije",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UlogaId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Uloge_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Uloge",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CVVjestine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VjestinaId = table.Column<int>(type: "int", nullable: false),
                    CVId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVVjestine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVVjestine_CV_CVId",
                        column: x => x.CVId,
                        principalTable: "CV",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CVVjestine_Vjestine_VjestinaId",
                        column: x => x.VjestinaId,
                        principalTable: "Vjestine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnikId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IPAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kandidati",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MjestoPrebivalista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zvanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kandidati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kandidati_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kompanije",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GodinaOsnivanja = table.Column<int>(type: "int", nullable: false),
                    Lokacija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojZaposlenih = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KratkiOpis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompanije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kompanije_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikNotifikacije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NotifikacijaId = table.Column<int>(type: "int", nullable: false),
                    DatumPrimanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pogledano = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikNotifikacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KorisnikNotifikacije_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KorisnikNotifikacije_Notifikacije_NotifikacijaId",
                        column: x => x.NotifikacijaId,
                        principalTable: "Notifikacije",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recenzije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnikId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrojZvijezdica = table.Column<int>(type: "int", nullable: false),
                    DatumVrijemeRecenzije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pozicija = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recenzije_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KandidatSpaseneKompanije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KandidatId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KompanijaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Spasen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KandidatSpaseneKompanije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KandidatSpaseneKompanije_Kandidati_KandidatId",
                        column: x => x.KandidatId,
                        principalTable: "Kandidati",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KandidatSpaseneKompanije_Kompanije_KompanijaId",
                        column: x => x.KompanijaId,
                        principalTable: "Kompanije",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KompanijaLokacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KompanijaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LokacijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompanijaLokacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KompanijaLokacija_Kompanije_KompanijaId",
                        column: x => x.KompanijaId,
                        principalTable: "Kompanije",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KompanijaLokacija_Lokacija_LokacijaId",
                        column: x => x.LokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KompanijeKandidati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KompanijaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KandidatId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DatumRazgovora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompanijeKandidati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KompanijeKandidati_Kandidati_KandidatId",
                        column: x => x.KandidatId,
                        principalTable: "Kandidati",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KompanijeKandidati_Kompanije_KompanijaId",
                        column: x => x.KompanijaId,
                        principalTable: "Kompanije",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Oglasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KompanijaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NazivPozicije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumObjave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Plata = table.Column<double>(type: "float", nullable: false),
                    TipPosla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RokPrijave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumModificiranja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oglasi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oglasi_Kompanije_KompanijaId",
                        column: x => x.KompanijaId,
                        principalTable: "Kompanije",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KandidatiOglasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KandidatId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OglasId = table.Column<int>(type: "int", nullable: false),
                    DatumPrijave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KandidatiOglasi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KandidatiOglasi_Kandidati_KandidatId",
                        column: x => x.KandidatId,
                        principalTable: "Kandidati",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KandidatiOglasi_Oglasi_OglasId",
                        column: x => x.OglasId,
                        principalTable: "Oglasi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KandidatSpaseniOglasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KandidatId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OglasId = table.Column<int>(type: "int", nullable: false),
                    Spasen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KandidatSpaseniOglasi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KandidatSpaseniOglasi_Kandidati_KandidatId",
                        column: x => x.KandidatId,
                        principalTable: "Kandidati",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KandidatSpaseniOglasi_Oglasi_OglasId",
                        column: x => x.OglasId,
                        principalTable: "Oglasi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OglasIskustvo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OglasId = table.Column<int>(type: "int", nullable: false),
                    IskustvoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OglasIskustvo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OglasIskustvo_Iskustvo_IskustvoId",
                        column: x => x.IskustvoId,
                        principalTable: "Iskustvo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OglasIskustvo_Oglasi_OglasId",
                        column: x => x.OglasId,
                        principalTable: "Oglasi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OglasLokacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OglasId = table.Column<int>(type: "int", nullable: false),
                    LokacijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OglasLokacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OglasLokacija_Lokacija_LokacijaId",
                        column: x => x.LokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OglasLokacija_Oglasi_OglasId",
                        column: x => x.OglasId,
                        principalTable: "Oglasi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpisOglas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpisPozicije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumGodinaIskustva = table.Column<int>(type: "int", nullable: false),
                    PrefiraneGodineIskstva = table.Column<int>(type: "int", nullable: false),
                    Kvalifikacija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vjestine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Benefiti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OglasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpisOglas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpisOglas_Oglasi_OglasId",
                        column: x => x.OglasId,
                        principalTable: "Oglasi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UlogaId",
                table: "AspNetUsers",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnikId",
                table: "AutentifikacijaToken",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_CVJezici_CVId",
                table: "CVJezici",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CVJezici_JezikId",
                table: "CVJezici",
                column: "JezikId");

            migrationBuilder.CreateIndex(
                name: "IX_CVTehnologije_CVId",
                table: "CVTehnologije",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CVTehnologije_TehnologijaId",
                table: "CVTehnologije",
                column: "TehnologijaId");

            migrationBuilder.CreateIndex(
                name: "IX_CVVjestine_CVId",
                table: "CVVjestine",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CVVjestine_VjestinaId",
                table: "CVVjestine",
                column: "VjestinaId");

            migrationBuilder.CreateIndex(
                name: "IX_KandidatiOglasi_KandidatId",
                table: "KandidatiOglasi",
                column: "KandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_KandidatiOglasi_OglasId",
                table: "KandidatiOglasi",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_KandidatSpaseneKompanije_KandidatId",
                table: "KandidatSpaseneKompanije",
                column: "KandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_KandidatSpaseneKompanije_KompanijaId",
                table: "KandidatSpaseneKompanije",
                column: "KompanijaId");

            migrationBuilder.CreateIndex(
                name: "IX_KandidatSpaseniOglasi_KandidatId",
                table: "KandidatSpaseniOglasi",
                column: "KandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_KandidatSpaseniOglasi_OglasId",
                table: "KandidatSpaseniOglasi",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_KompanijaLokacija_KompanijaId",
                table: "KompanijaLokacija",
                column: "KompanijaId");

            migrationBuilder.CreateIndex(
                name: "IX_KompanijaLokacija_LokacijaId",
                table: "KompanijaLokacija",
                column: "LokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_KompanijeKandidati_KandidatId",
                table: "KompanijeKandidati",
                column: "KandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_KompanijeKandidati_KompanijaId",
                table: "KompanijeKandidati",
                column: "KompanijaId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikNotifikacije_KorisnikId",
                table: "KorisnikNotifikacije",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikNotifikacije_NotifikacijaId",
                table: "KorisnikNotifikacije",
                column: "NotifikacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oglasi_KompanijaId",
                table: "Oglasi",
                column: "KompanijaId");

            migrationBuilder.CreateIndex(
                name: "IX_OglasIskustvo_IskustvoId",
                table: "OglasIskustvo",
                column: "IskustvoId");

            migrationBuilder.CreateIndex(
                name: "IX_OglasIskustvo_OglasId",
                table: "OglasIskustvo",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_OglasLokacija_LokacijaId",
                table: "OglasLokacija",
                column: "LokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_OglasLokacija_OglasId",
                table: "OglasLokacija",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_OpisOglas_OglasId",
                table: "OpisOglas",
                column: "OglasId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RadnoIskustvo_CVId",
                table: "RadnoIskustvo",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_KorisnikId",
                table: "Recenzije",
                column: "KorisnikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "CVJezici");

            migrationBuilder.DropTable(
                name: "CVTehnologije");

            migrationBuilder.DropTable(
                name: "CVVjestine");

            migrationBuilder.DropTable(
                name: "KandidatiOglasi");

            migrationBuilder.DropTable(
                name: "KandidatSpaseneKompanije");

            migrationBuilder.DropTable(
                name: "KandidatSpaseniOglasi");

            migrationBuilder.DropTable(
                name: "KompanijaLokacija");

            migrationBuilder.DropTable(
                name: "KompanijeKandidati");

            migrationBuilder.DropTable(
                name: "KorisnikNotifikacije");

            migrationBuilder.DropTable(
                name: "OglasIskustvo");

            migrationBuilder.DropTable(
                name: "OglasLokacija");

            migrationBuilder.DropTable(
                name: "OpisiKompanija");

            migrationBuilder.DropTable(
                name: "OpisOglas");

            migrationBuilder.DropTable(
                name: "RadnoIskustvo");

            migrationBuilder.DropTable(
                name: "Recenzije");

            migrationBuilder.DropTable(
                name: "Teme");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Jezici");

            migrationBuilder.DropTable(
                name: "Tehnologije");

            migrationBuilder.DropTable(
                name: "Vjestine");

            migrationBuilder.DropTable(
                name: "Kandidati");

            migrationBuilder.DropTable(
                name: "Notifikacije");

            migrationBuilder.DropTable(
                name: "Iskustvo");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "Oglasi");

            migrationBuilder.DropTable(
                name: "CV");

            migrationBuilder.DropTable(
                name: "Kompanije");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Uloge");
        }
    }
}
