using StockLedge.Data.DiConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.DbContextDiConfig(builder.Configuration);
builder.Services.AddRepositoriesDiConfig();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
