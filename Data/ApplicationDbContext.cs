using JobSearchingWebApp.Database;
using JobSearchingWebApp.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobSearchingWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Korisnik>
    {
        public DbSet<Korisnik> Korisnici { get; set; }

        public DbSet<Kompanija> Kompanije { get; set; }

        public DbSet<Kandidat> Kandidati { get; set; }

        public DbSet<Oglas> Oglasi { get; set; }

        public DbSet<Notifikacija> Notifikacije { get; set; }

        public DbSet<CV> CV { get; set; }

        public DbSet<KandidatiOglasi> KandidatiOglasi { get; set; }

        public DbSet<KompanijeKandidati> KompanijeKandidati { get; set; }

        public DbSet<KorisnikNotifikacije> KorisnikNotifikacije { get; set; }

        public DbSet<CVEdukacija> CVEdukacija { get; set; }

        public DbSet<Edukacija> Edukacija { get; set; }

        public DbSet<URL> URL { get; set; }

        public DbSet<CVURL> CVURL { get; set; }

        public DbSet<CVZaposlenje> CVZaposlenje { get; set; }

        public DbSet<Zaposlenje> Zaposlenje { get; set; }

        public DbSet<Lokacija> Lokacija { get; set; }

        public DbSet<Iskustvo> Iskustvo { get; set; }

        public DbSet<OglasIskustvo> OglasIskustvo { get; set; }

        public DbSet<OglasLokacija> OglasLokacija { get; set; }

        public DbSet<OpisOglas> OpisOglas { get; set; }

        public DbSet<KandidatSpaseniOglasi> KandidatSpaseniOglasi { get; set; }

        public DbSet<KandidatSpaseneKompanije> KandidatSpaseneKompanije { get; set; }

        public DbSet<Uloga> Uloge { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
            modelBuilder.Entity<Oglas>()
            .HasMany(o => o.OglasIskustvo)
            .WithOne(oi => oi.Oglas)
            .HasForeignKey(oi => oi.OglasId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
