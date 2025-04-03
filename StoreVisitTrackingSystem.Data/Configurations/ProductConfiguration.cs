using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreVisitTrackingSystem.Data.Entities;

namespace StoreVisitTrackingSystem.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Category)
            .HasMaxLength(100);

        builder.Property(p => p.CreatedAt)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(p => p.Photos)
            .WithOne(photo => photo.Product)
            .HasForeignKey(photo => photo.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
