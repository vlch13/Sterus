using Core.Entities;

namespace Core.Specifications
{
	public class ProductsWithCompaniesSpecification : BaseSpecification<Product>
	{
		public ProductsWithCompaniesSpecification(string sort)
		{
			AddInclude(x => x.ProductCompany);
			AddOrderBy(x => x.ProductCompany);

			if (!string.IsNullOrEmpty(sort))
			{
				switch (sort)
				{
					case "priceAsc":
						AddOrderBy(p => p.Price);
						break;
					case "priceDesc":
						AddOrderByDescending(p => p.Price);
						break;
					default:
						AddOrderBy(n => n.ProductCompany);
						break;
				}
			}
		}

			public ProductsWithCompaniesSpecification(int id) : base(x => x.Id == id)
		{
			AddInclude(x => x.ProductCompany);
		}
	}
}