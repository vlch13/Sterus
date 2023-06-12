using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
	{
		public static IQueryable<TEntity> GetQuary(IQueryable<TEntity> inputQuary, 
		ISpecification<TEntity> spec)
		{
			var quary = inputQuary;
			
			if(spec.Criteria != null)
			{
				quary = quary.Where(spec.Criteria);
			}
			
			if (spec.OrderBy != null)
			{
				quary = quary.OrderBy(spec.OrderBy);
			}

			if (spec.OrderByDescending != null)
			{
				quary = quary.OrderByDescending(spec.OrderByDescending);
			}

			if (spec.IsPagingEnabled)
			{
				quary = quary.Skip(spec.Skip).Take(spec.Take);
			}
			
			quary = spec.Includes.Aggregate(quary, (current, include) => current.Include(include));
			return quary;
		}
	}
}