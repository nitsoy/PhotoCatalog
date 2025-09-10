using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoCatalog.Core.Entities;

namespace PhotoCatalog.Infrastructure.Data.Configurations;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> b)
    {
        b.ToTable("Photos");
        b.HasKey(p => p.Id);

        b.Property<int>("Id").HasColumnName("Id");
        b.Property(p => p.Title).HasMaxLength(120).IsRequired();
        b.Property(p => p.Url).HasMaxLength(200);
        b.Property(p => p.TakenAt);
        b.Property(p => p.Tags).HasMaxLength(200);

        b.HasIndex(p => p.Title);
        b.HasIndex(p => p.TakenAt);
    }
}
