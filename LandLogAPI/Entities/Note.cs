using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LandLogAPI.Entities
{
    public abstract class Note : IEntityTypeConfiguration<Note>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder
                .HasDiscriminator<string>("note_type")
                .HasValue<Note>("note_base")
                .HasValue<ParcelNote>("parcel_note")
                .HasValue<ProjectNote>("project_note");


            builder.Property(x => x.Title).HasMaxLength(255);
            builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd();
            builder.Property(x => x.UpdatedAt).ValueGeneratedOnUpdate();
        }
    }

    public class ParcelNote : Note
    {
        public Parcel Parcel { get; set; }
        public string ParcelIdentifier { get; set; }
    }
    public class ProjectNote : Note
    {
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}
