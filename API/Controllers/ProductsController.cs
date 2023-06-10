using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly IGenericRepository<Product> _productRepo;
		private readonly IGenericRepository<ProductCompany> _productCompanyRepo;

		public ProductsController(IGenericRepository<Product> productRepo,
		IGenericRepository<ProductCompany> productCompanyRepo)
		{
			_productRepo = productRepo;
			_productCompanyRepo = productCompanyRepo;
		}

		[HttpGet]
		public async Task<ActionResult<List<Product>>> GetProducts()
		{
			var spec = new ProductsWithCompaniesSpecification();

			var products = await _productRepo.ListAsync(spec);

			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			var spec = new ProductsWithCompaniesSpecification(id);

			return await _productRepo.GetEntityWithSpec(spec);
		}

		[HttpGet("companies")]
		public async Task<ActionResult<IReadOnlyList<ProductCompany>>> GetProductCompanies()
		{
			return Ok(await _productCompanyRepo.ListAllAsync());
		}
	}
}