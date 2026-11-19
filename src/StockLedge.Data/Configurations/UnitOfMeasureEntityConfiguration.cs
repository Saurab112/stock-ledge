using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockLedge.Domain.Uoms;

namespace StockLedge.Data.Configurations
{
	public class UnitOfMeasureEntityConfiguration : IEntityTypeConfiguration<UnitOfMeasureEntity>
	{
		public void Configure(EntityTypeBuilder<UnitOfMeasureEntity> builder)
		{
			builder.ToTable("UnitsOfMeasure");

			builder.HasKey(u => u.Id);

			builder.Property(u => u.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(u => u.Code)
				.IsRequired()
				.HasMaxLength(20);

			builder.Property(u => u.Multiplier)
				.IsRequired()
				.HasPrecision(18, 6);

			builder.Property(u => u.IsBase)
				.IsRequired();

			builder.Property(u => u.IsActive)
				.IsRequired();

			builder.Property(u => u.UnitOfMeasureGroupId)
				.IsRequired();

			builder.HasOne(u => u.UomGroup)
				.WithMany(g => g.Units)
				.HasForeignKey(u => u.UnitOfMeasureGroupId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasIndex(u => new { u.UnitOfMeasureGroupId, u.Code })
				.IsUnique();

			builder.HasIndex(u => new { u.UnitOfMeasureGroupId, u.Name })
				.IsUnique();

		}
	}
}
