using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class ProductsController : BaseApiController
	{
		private readonly IGenericRepository<Product> _productRepo;
		private readonly IGenericRepository<ProductCompany> _productCompanyRepo;
		private readonly IMapper _mapper;

		public ProductsController(IGenericRepository<Product> productRepo,
		IGenericRepository<ProductCompany> productCompanyRepo, IMapper mapper)
		{
			_mapper = mapper;
			_productRepo = productRepo;
			_productCompanyRepo = productCompanyRepo;
		}

		[HttpGet]
		public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
		{
			var spec = new ProductsWithCompaniesSpecification();

			var products = await _productRepo.ListAsync(spec);

			return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
		{
			var spec = new ProductsWithCompaniesSpecification(id);

			var product = await _productRepo.GetEntityWithSpec(spec);

			return _mapper.Map<Product, ProductToReturnDto>(product);
		}

		[HttpGet("companies")]
		public async Task<ActionResult<IReadOnlyList<ProductCompany>>> GetProductCompanies()
		{
			return Ok(await _productCompanyRepo.ListAllAsync());
		}
	}
}