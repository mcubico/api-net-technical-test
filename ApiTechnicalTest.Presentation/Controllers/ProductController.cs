using ApiTechnicalTest.Data.Entities;
using ApiTechnicalTest.Domain.Interfaces.Repositories;
using ArandaTechnicalTest.Presentation.Models;
using ArandaTechnicalTest.Presentation.ModelsDTO;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArandaTechnicalTest.Presentation.Controllers
{
    [Route("api/[controller]")]
    [RequireHttps]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region ATTRIBUTES

        private readonly IProductRepository _repo;
        private readonly ICategoryRepository _repoCategory;
        private readonly ISupplierRepository _repoSupplier;
        private readonly IMapper _mapper;
        public static IWebHostEnvironment? _environment;

        #endregion

        #region CONSTRUCTORS

        public ProductController(
            IProductRepository repo, 
            ICategoryRepository repoCategory,
            ISupplierRepository repoSupplier,
            IMapper mapper, 
            IWebHostEnvironment environment)
        {
            _repo = repo;
            _repoCategory = repoCategory;
            _repoSupplier = repoSupplier;
            _mapper = mapper;
            _environment = environment;
        }

        #endregion

        #region CRUD ACTIONS

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(ProductDTO), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromForm] ProductCreationDTO data)
        {
            bool existsCategory = await _repoCategory.CategoryExistAsync(data.CategoryId);
            if (!existsCategory)
                return BadRequest($"The category with id [{data.CategoryId}] doesn´t exist");

            bool existsSupplier = await _repoSupplier.SupplierExistAsync(data.SupplierId);
            if (!existsSupplier)
                return BadRequest($"The supplier with id [{data.SupplierId}] doesn´t exist");

            ProductEntity product = _mapper.Map<ProductEntity>(data);

            product = await _repo.AddAsync(product);

            var productDTO = _mapper.Map<ProductDTO>(product);
            return CreatedAtAction(null, productDTO);
        }

        #endregion

        #region SEARCH ACTIONS

        [HttpGet]
        [ProducesResponseType(type: typeof(List<ProductDTO>), statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductDTO>>> Get([FromQuery] QueryParametersPagination parameters)
        {
            parameters.Page = parameters.Page == 0 ? 1 : parameters.Page;
            parameters.ItemsPerPage = parameters.ItemsPerPage == 0 
                ? 5 
                : parameters.ItemsPerPage > 100
                    ? 100
                    : parameters.ItemsPerPage;

            int totalProducts = await _repo.GetTotalRecordsAsync();

            // Agrego a la cabecera de la respuesta la cantidad total de registros que existen
            // en la tabla
            Response.Headers.Add("X-Total-Records", totalProducts.ToString());

            var products = await _repo.GetAllAsync(parameters.Page, parameters.ItemsPerPage);
            var productsDto = _mapper.Map<List<ProductDTO>>(products);

            return Ok(productsDto);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(ProductDTO), statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductDTO>>> Get(Guid id)
        {
            var products = await _repo.GetByIdAsync(id);
            ProductDTO productsDto = _mapper.Map<ProductDTO>(products);

            return Ok(productsDto);
        }

        #endregion
    }
}
