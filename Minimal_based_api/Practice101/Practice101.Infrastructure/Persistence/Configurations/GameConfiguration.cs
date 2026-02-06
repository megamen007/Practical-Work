using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameApi.Api.Entities;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Games");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Title)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(m => m.Genre)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(m => m.ReleaseDate)
               .IsRequired();

        builder.Property(m => m.Rating)
               .IsRequired();    

        builder.Property(m => m.Created)
               .IsRequired()
               .ValueGeneratedOnAdd();

        builder.Property(m => m.LastModified)
               .IsRequired()
               .ValueGeneratedOnUpdate();

        builder.HasIndex(m => m.Title);
    }
}