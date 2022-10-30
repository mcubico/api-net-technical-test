using ArandaTechnicalTest.Data.Entities;
using ArandaTechnicalTest.Domain.Interfaces.Repositories;
using ArandaTechnicalTest.Presentation.ModelsDTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArandaTechnicalTest.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region ATTRIBUTES

        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public static IWebHostEnvironment _environment;

        #endregion

        #region CONSTRUCTORS
        public ProductsController(IProductRepository repo, IMapper mapper, IWebHostEnvironment environment)
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
            data.Image = saveImage(data.File);

            Products product = _mapper.Map<Products>(data);

            product = await _repo.AddAsync(product);

            var productDTO = _mapper.Map<ProductDTO>(product);
            return CreatedAtAction(null, productDTO);
        }

        [HttpPut]
        [ProducesResponseType(type: typeof(ProblemDetails), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(ProblemDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put([FromForm] ProductDTO data)
        {
            bool exists = await _repo.ExistsProduct(data.Id);
            if (!exists)
                return NotFound();

            data.Image = saveImage(data.File);

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

        [HttpGet("{page:int}/{itemsPerPage:int}")]
        [ProducesResponseType(type: typeof(List<ProductDTO>), statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductDTO>>> Get(int page = 1, int itemsPerPage = 5)
        {
            page = page == 0 ? 1 : page;
            itemsPerPage = itemsPerPage == 0 ? 5 : itemsPerPage;
            int totalProducts = await _repo.GetTotalRecordsAsync();

            // Agrego a la cabecera de la respuesta la cantidad total de registros que existen
            // en la tabla
            Response.Headers["X-Total-Records"] = totalProducts.ToString();

            // Agrego a la cabecera de la respuesta la cantidad de páginas disponibles acorde a
            // la cantidad de items por por página que desea obtener
            Response.Headers["X-Total-Pages"] = (totalProducts / itemsPerPage).ToString();

            var products = await _repo.GetAllAsync(page, itemsPerPage);
            var productsDto = _mapper.Map<List<ProductDTO>>(products);

            return Ok(productsDto);
        }

        [HttpGet("total")]
        [ProducesResponseType(type: typeof(int), statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> GetTotal()
        {
            int response = await _repo.GetTotalRecordsAsync();
            return Ok(response);
        }

        #endregion

        #region METHODS

        private string saveImage(IFormFile? file)
        {
            if (file == null || file.Length == 0)
                return string.Empty;

            if (!Directory.Exists(_environment.WebRootPath + "\\Upload"))
                Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");

            using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + file.FileName))
            {
                file.CopyTo(filestream);
                filestream.Flush();
            }

            return file.FileName;
        }

        #endregion
    }
}
