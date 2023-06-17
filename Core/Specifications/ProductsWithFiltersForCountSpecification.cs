using Core.Entities;

namespace Core.Specifications
{
	public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
	{
		public ProductsWithFiltersForCountSpecification(ProductSpecParams productParams)
		: base(x =>
			// (string.IsNullOrEmpty(productParams.Search) || x.ProductCompany.Name.ToLower().Contains
			// (productParams.Search)) &&
			// (!productParams.CompanyId.HasValue || x.ProductCompanyId == productParams.CompanyId))

			((string.IsNullOrEmpty(productParams.Search) || x.ProductCompany.Name.ToLower().Contains
			(productParams.Search)) ||
			(string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains
			(productParams.Search))) &&
			(!productParams.CompanyId.HasValue || x.ProductCompanyId == productParams.CompanyId))
		{
		}
	}
}