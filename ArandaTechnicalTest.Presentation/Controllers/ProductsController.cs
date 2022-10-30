using ArandaTechnicalTest.Data.Entities;
using ArandaTechnicalTest.Domain.Interfaces.Repositories;
using ArandaTechnicalTest.Presentation.ModelsDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArandaTechnicalTest.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region ATTRIBUTES

        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        #endregion

        #region CONSTRUCTORS
        public ProductsController(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        #endregion

        #region CRUD ACTIONS

        [HttpPost]
        [ProducesResponseType(type: typeof(ProblemDetails), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(ProductDTO), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] ProductCreationDTO data)
        {
            Products product = _mapper.Map<Products>(data);

            product = await _repo.AddAsync(product);

            var productDTO = _mapper.Map<ProductDTO>(product);
            return CreatedAtAction(null, productDTO);
        }

        [HttpPut]
        [ProducesResponseType(type: typeof(ProblemDetails), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(ProblemDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put([FromBody] ProductDTO data)
        {
            bool exists = await _repo.ExistsProduct(data.Id);
            if (!exists)
                return NotFound();

            Products product = _mapper.Map<Products>(data);
            _ = await _repo.UpdateAsync(product);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(type: typeof(ProblemDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool exists = await _repo.ExistsProduct(id);
            if (!exists)
                return NotFound();

            _ = await _repo.DeleteAsync(id);

            return Ok();
        }

        #endregion

        #region SEARCH ACTIONS

        [HttpGet("{page:int:min(1)}/{itemsPerPage:int:min(1)}")]
        [ProducesResponseType(type: typeof(ProblemDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(List<ProductDTO>), statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductDTO>>> Get(int page = 1, int itemsPerPage = 10)
        {
            int totalProducts = await _repo.GetTotalRecordsAsync();

            // Agrego a la cabecera de la respuesta la cantidad total de registros que existen
            // en la tabla
            Response.Headers["X-Total-Records"] = totalProducts.ToString();

            // Agrego a la cabecera de la respuesta la cantidad de páginas disponibles acorde a
            // la cantidad de items por por página que desea obtener
            Response.Headers["X-Total-Pages"] = (totalProducts / itemsPerPage).ToString();

            var products = await _repo.GetAllAsync(page, itemsPerPage);
            var productsDto = _mapper.Map<List<ProductDTO>>(products);

            return products == null || productsDto.Count == 0
                ? NotFound()
                : Ok(productsDto);
        }

        #endregion
    }
}
