using Core.Entities;

namespace Core.Specifications
{
	public class ProductsWithCompaniesSpecification : BaseSpecification<Product>
	{
		public ProductsWithCompaniesSpecification()
		{
			AddInclude(x => x.ProductCompany);
		}

			public ProductsWithCompaniesSpecification(int id) : base(x => x.Id == id)
		{
			AddInclude(x => x.ProductCompany);
		}
	}
}