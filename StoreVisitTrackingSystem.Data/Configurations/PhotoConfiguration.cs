using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data.Entities;

namespace StoreVisitTrackingSystem.Data.Configurations;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.ToTable("Photos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Base64Image)
            .IsRequired()
            .HasColumnType("longtext");

        builder.Property(p => p.UploadedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(p => p.Visit)
            .WithMany(v => v.Photos)
            .HasForeignKey(p => p.VisitId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Product)
            .WithMany(pr => pr.Photos)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
