﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StoreVisitTrackingSystem.Data.Entities;

namespace StoreVisitTrackingSystem.Data.Configurations;

public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.ToTable("Visits");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.VisitDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(v => v.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasOne(v => v.User)
            .WithMany(u => u.Visits)
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(v => v.Store)
            .WithMany(s => s.Visits)
            .HasForeignKey(v => v.StoreId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(v => v.Photos)
            .WithOne(p => p.Visit)
            .HasForeignKey(p => p.VisitId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

