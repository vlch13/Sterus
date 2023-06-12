using Core.Entities;

namespace Core.Specifications
{
	public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
	{
		public ProductsWithFiltersForCountSpecification(ProductSpecParams productParams)
		: base(x =>
			(!productParams.CompanyId.HasValue || x.ProductCompanyId == productParams.CompanyId))
		{
		}
	}
}