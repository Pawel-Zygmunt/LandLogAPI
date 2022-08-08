using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

//Jeśli nullable jest zakomentowane, to domyślnie wszystkie typy referencyjne
//mogą przyjmować wartości null, bedziemy w stanie przekazać wartości null po stronie
//sql

//Jeśli jest odkomentowane to nie zezwala na null i trzeba deklarować np: string?

namespace LandLogAPI.Entities
{
    public class AppDbContext: IdentityDbContext<AppUser, AppRole, UserId>
    {
        public DbSet<ProjectNote> ProjectNotes { get; set; }
        public DbSet<ParcelNote> ParcelNotes { get; set; }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<Project> Projects { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresExtension("postgis");
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.HasDefaultSchema("xzy"); //TODO: change for something meaningful 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
