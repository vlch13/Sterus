using API.Extensions;
using API.MiddleWare;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

// if (app.Environment.IsDevelopment())
// {
	app.UseSwagger();
	app.UseSwaggerUI();
// }

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<DataContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
	await context.Database.MigrateAsync();
}
catch (Exception ex)
{

	logger.LogError(ex, "Error during migration");
}

app.Run();
