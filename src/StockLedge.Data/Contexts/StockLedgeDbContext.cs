using Microsoft.EntityFrameworkCore;
using StockLedge.Domain.Uoms;

namespace StockLedge.Data.Contexts
{
	public class StockLedgeDbContext : DbContext
	{
		public StockLedgeDbContext(DbContextOptions<StockLedgeDbContext> options)
			: base(options)
		{
		}

		public DbSet<UnitOfMeasureGroupEntity> UomGroups => Set<UnitOfMeasureGroupEntity>();
		public DbSet<UnitOfMeasureEntity> UnitsOfMeasure => Set<UnitOfMeasureEntity>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockLedgeDbContext).Assembly);
		}
	}
}
