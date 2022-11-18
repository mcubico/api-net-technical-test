using ApiTechnicalTest.Data.Entities;
using ApiTechnicalTest.Domain.Interfaces.Repositories;
using ArandaTechnicalTest.Presentation.Models;
using ArandaTechnicalTest.Presentation.ModelsDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArandaTechnicalTest.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region ATTRIBUTES

        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public static IWebHostEnvironment? _environment;

        #endregion

        #region CONSTRUCTORS

        public ProductController(
            IProductRepository repo, 
            IMapper mapper, 
            IWebHostEnvironment environment)
        {
            _repo = repo;
            _mapper = mapper;
            _environment = environment;
        }

        #endregion

        #region CRUD ACTIONS

        [HttpPost]
        [ProducesResponseType(type: typeof(ProblemDetails), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(ProductDTO), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromForm] ProductCreationDTO data)
        {
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
            parameters.ItemsPerPage = parameters.ItemsPerPage == 0 ? 5 : parameters.ItemsPerPage;
            int totalProducts = await _repo.GetTotalRecordsAsync();

            // Agrego a la cabecera de la respuesta la cantidad total de registros que existen
            // en la tabla
            Response.Headers.Add("X-Total-Records", totalProducts.ToString());

            var products = await _repo.GetAllAsync(parameters.Page, parameters.ItemsPerPage, parameters.SortBy, parameters.DirectionAsc);
            var productsDto = _mapper.Map<List<ProductDTO>>(products);

            return Ok(productsDto);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(type: typeof(ProductDTO), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ProductDTO), statusCode: StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ProductDTO>>> Get(Guid id)
        {
            var products = await _repo.GetByIdAsync(id);
            ProductDTO productsDto = _mapper.Map<ProductDTO>(products);

            return Ok(productsDto);
        }

        #endregion
    }
}
