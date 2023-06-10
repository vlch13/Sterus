using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class ProductRepository : IProductRepository
	{
		private readonly DataContext _context;
		public ProductRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<Product> GetProductByIdAsync(int id)
		{
			return await _context.Products
			.Include(p => p.ProductCompany)
			.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<IReadOnlyList<ProductCompany>> GetProductCompaniesAsync()
		{
			return await _context.ProductCompanies.ToListAsync();
		}

		public async Task<IReadOnlyList<Product>> GetProductsAsync()
		{
			return await _context.Products
			.Include(p => p.ProductCompany)
			.ToListAsync();
		}
	}
}