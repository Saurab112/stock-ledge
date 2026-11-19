using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockLedge.Domain.Uoms;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockLedge.Data.Configurations
{
	public class UomGroupEntityConfiguration : IEntityTypeConfiguration<UnitOfMeasureGroupEntity>
	{
		public void Configure(EntityTypeBuilder<UnitOfMeasureGroupEntity> builder)
		{
			builder.ToTable("UomGroup");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.Code)
				.IsRequired()
				.HasMaxLength(20);

			builder.Property(x => x.IsActive)
				.IsRequired()
				.HasDefaultValue(true);

			builder.HasIndex(x => x.Code)
				.IsUnique();

			builder.HasMany(x => x.Units)
				.WithOne(x => x.UomGroup)
				.HasForeignKey(x => x.UnitOfMeasureGroupId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Navigation(x => x.Units)
				.UsePropertyAccessMode(PropertyAccessMode.Field);

			builder.Ignore(x => x.BaseUnit);
		}
	}
}
