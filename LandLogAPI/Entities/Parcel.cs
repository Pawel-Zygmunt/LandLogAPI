using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LandLogAPI.Entities
{
    public record ParcelId(string Id)
    {
        public static implicit operator string(ParcelId id) => id.Id;
        public static implicit operator ParcelId(string id) => new(id);
    }

    public class Parcel : IEntityTypeConfiguration<Parcel>
    {
        public ParcelId Id { get; set; }
        public string Identifier { get; set; }
        public string Voivodeship { get; set; }
        public string County { get; set; }
        public string Commune { get; set; }
        public string Region { get; set; }
        public string ParcelNum { get; set; }
        public string CreatedAt { get; set; }

        public List<ParcelNote> Notes { get; set; } = new List<ParcelNote>();

        public Project Project { get; set; }
        public Guid ProjectId { get; set; }

        public void Configure(EntityTypeBuilder<Parcel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Id, x => new ParcelId(x));

            builder.Property(x => x.Voivodeship).HasMaxLength(255);
            builder.Property(x => x.County).HasMaxLength(255);
            builder.Property(x => x.Commune).HasMaxLength(255);
            builder.Property(x => x.Region).HasMaxLength(255);
            builder.Property(x => x.ParcelNum).HasMaxLength(255);
            builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd();

            builder.HasMany(p => p.Notes)
                .WithOne(n => n.Parcel)
                .HasForeignKey(n => n.ParcelId)
                .IsRequired();
        }
    }
}
