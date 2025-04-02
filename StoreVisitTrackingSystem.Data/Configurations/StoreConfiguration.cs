﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data.Entities;

namespace StoreVisitTrackingSystem.Data.Configurations;

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable("Stores");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.Location)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(s => s.CreatedAt)
               .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(s => s.Visits)
               .WithOne(v => v.Store)
               .HasForeignKey(v => v.StoreId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
