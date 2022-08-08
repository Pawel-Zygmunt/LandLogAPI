using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LandLogAPI.Entities
{
    public record NoteId(Guid Id)
    {
        public static implicit operator Guid(NoteId id) => id.Id;
        public static implicit operator NoteId(Guid id) => new(id);
    }

    public abstract class Note : IEntityTypeConfiguration<Note>
    {
        public NoteId Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.Property(x => x.Id)
               .HasConversion(x => x.Id, x => new NoteId(x));

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
        public ParcelId ParcelId { get; set; }
    }
    public class ProjectNote : Note
    {
        public Project Project { get; set; }
        public ProjectId ProjectId { get; set; }
    }
}
