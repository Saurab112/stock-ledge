using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockLedge.Data.Contexts
{
	public class StockLedgeDbContext : DbContext
	{
		public StockLedgeDbContext(DbContextOptions<StockLedgeDbContext> options)
			: base(options)
		{
		}

		//db sets here

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockLedgeDbContext).Assembly);
		}
	}
}
