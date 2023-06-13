using Core.Entities;

namespace Core.Specifications
{
	public class ProductsWithCompaniesSpecification : BaseSpecification<Product>
	{
		public ProductsWithCompaniesSpecification(ProductSpecParams productParams)
		: base(x =>
			// (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains      //поиск по наименованию  - работает
			// (productParams.Search)) &&
			(string.IsNullOrEmpty(productParams.Search) || x.ProductCompany.Name.ToLower().Contains
			(productParams.Search)) &&
			(!productParams.CompanyId.HasValue || x.ProductCompanyId == productParams.CompanyId))
		{
			AddInclude(x => x.ProductCompany);
			AddOrderBy(x => x.ProductCompany);
			ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1),
			productParams.PageSize);

			if (!string.IsNullOrEmpty(productParams.Sort))
			{
				switch (productParams.Sort)
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