using ApiTechnicalTest.Data.Entities;
using ApiTechnicalTest.Domain.Interfaces.Repositories;
using ApiTechnicalTest.Presentation.ModelsDTO;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTechnicalTest.Presentation.Controllers
{
    /// <summary>
    /// Gestiona las acciones permitidas sobre la entidad categorías
    /// </summary>
    [Route("api/[controller]")]
    [RequireHttps]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region ATTRIBUTES

        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public static IWebHostEnvironment? _environment;

        #endregion

        #region CONSTRUCTORS

        public CategoryController(
            ICategoryRepository repo,
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
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(type: typeof(CategoryDTO), statusCode: StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromForm] CategoryCreationDTO data)
        {
            data.Picture = SaveImage(data.File);

            CategoryEntity category = _mapper.Map<CategoryEntity>(data);

            category = await _repo.AddAsync(category);

            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            return CreatedAtAction(null, categoryDTO);
        }

        #endregion

        #region METHODS

        private static string SaveImage(IFormFile? file)
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
