using System.Reflection;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCompany> ProductCompanies { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
			{
				foreach (var entityType in modelBuilder.Model.GetEntityTypes())
				{
					var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType
					== typeof(decimal));

					foreach (var property in properties)
					{
						modelBuilder.Entity(entityType.Name).Property(property.Name)
						.HasConversion<double>();
					}
				}
			}
		}
	}
}