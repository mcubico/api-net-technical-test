using ArandaTechnicalTest.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ArandaTechnicalTest.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pantalón bota ancha",
                    Category = "Pants",
                    Description ="Pantalón de bota ancha",
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Blusa campesina",
                    Category = "Blouses",
                    Description ="Blusa campesina"
                }
            };
        }
    }
}
