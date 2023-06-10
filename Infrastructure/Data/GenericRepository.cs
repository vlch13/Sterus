using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly DataContext _context;
		public GenericRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<IReadOnlyList<T>> ListAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}
	}
}