using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LandLogAPI.Entities
{
    public record UserId(Guid Id)
    {
        public static implicit operator Guid(UserId id) => id.Id;
        public static implicit operator UserId(Guid id) => new(id);
    }

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

           //builder.Property(x=>x.Id)
           //     .HasConversion(x=>x.)
        }
    }
}
