using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(p => p.Id).IsRequired();
			builder.Property(p => p.Name).IsRequired().HasMaxLength(128);
			builder.Property(p => p.BoxLenght).IsRequired();
			builder.Property(p => p.BoxHeight).IsRequired();
			builder.Property(p => p.BoxWidth).IsRequired();
			builder.Property(p => p.BoxWeight).IsRequired().HasMaxLength(10);
			builder.Property(p => p.Dose).IsRequired();
			builder.Property(p => p.DoseControl).IsRequired().HasMaxLength(10);
			builder.Property(p => p.Speed).IsRequired();
			builder.Property(p => p.IsMedical).IsRequired();
			builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
			builder.Property(p => p.Note).HasMaxLength(256);
			builder.HasOne(c => c.ProductCompany).WithMany()
				.HasForeignKey(c => c.ProductCompanyId);
		}
	}
}