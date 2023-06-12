using API.Dtos;
using API.Errors;
using API.Helpers;
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
		public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(
			[FromQuery] ProductSpecParams productParams)
		{
			var spec = new ProductsWithCompaniesSpecification(productParams);

			var countSpec = new ProductsWithFiltersForCountSpecification(productParams);

			var totalItems = await _productRepo.CountAsync(countSpec);

			var products = await _productRepo.ListAsync(spec);

			var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

			return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex,
			productParams.PageSize, totalItems, data));
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
		public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
		{
			var spec = new ProductsWithCompaniesSpecification(id);

			var product = await _productRepo.GetEntityWithSpec(spec);

			if (product == null) return NotFound(new ApiResponse(404));

			return _mapper.Map<Product, ProductToReturnDto>(product);
		}

		[HttpGet("companies")]
		public async Task<ActionResult<IReadOnlyList<ProductCompany>>> GetProductCompanies()
		{
			return Ok(await _productCompanyRepo.ListAllAsync());
		}
	}
}