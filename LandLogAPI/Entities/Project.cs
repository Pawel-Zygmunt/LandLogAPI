using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace LandLogAPI.Entities
{
    public record ProjectId(Guid Id)
    {
        public static implicit operator Guid(ProjectId id) => id.Id;
        public static implicit operator ProjectId(Guid id) => new(id);
    }

    public class Project : IEntityTypeConfiguration<Project>
    {
        public ProjectId Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Color { get; set; }

        public List<Parcel> Parcels { get; set; } = new List<Parcel>();
        public List<ProjectNote> Notes { get; set; } = new List<ProjectNote>();

        public AppUser Owner { get; set; }
        public Guid OwnerId { get; set; }


        public void Configure(EntityTypeBuilder<Project> builder)
        {
            
            builder.Property(x => x.Id)
                .HasConversion(x => x.Id, x => new ProjectId(x));
            builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd();
            builder.Property(x => x.Color).HasMaxLength(10);

            builder
                .HasMany(proj => proj.Parcels)
                .WithOne(parcel => parcel.Project)
                .HasForeignKey(parcel => parcel.ProjectId)
                .IsRequired();

            builder
                .HasMany(proj => proj.Notes)
                .WithOne(n => n.Project)
                .HasForeignKey(n => n.ProjectId)
                .IsRequired();
        }

    }
}
