using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockLedge.Data.Contexts
{
	public sealed class StockLedgeDbContextFactory : IDesignTimeDbContextFactory<StockLedgeDbContext>
	{
		public StockLedgeDbContext CreateDbContext(string[] args)
		{
			var connectionString =
				Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
				?? "Server=localhost;Port=3306;Database=stock-ledge-system;User=root;Password=;";

			var optionsBuilder = new DbContextOptionsBuilder<StockLedgeDbContext>();
			optionsBuilder.UseMySql(
				connectionString,
				ServerVersion.AutoDetect(connectionString));

			return new StockLedgeDbContext(optionsBuilder.Options);
		}
	}
}
