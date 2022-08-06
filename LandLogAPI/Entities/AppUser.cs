using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LandLogAPI.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntityTypeConfiguration<AppUser>
    {
        public List<Project> Projects { get; set; } = new List<Project>();

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .HasMany(p=>p.Projects)
                .WithOne(p => p.Owner)
                .HasForeignKey(p => p.OwnerId)
                .IsRequired();
        }
    }
}
