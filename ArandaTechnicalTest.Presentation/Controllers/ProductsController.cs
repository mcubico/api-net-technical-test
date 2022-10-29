using ArandaTechnicalTest.Data.Context;
using ArandaTechnicalTest.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArandaTechnicalTest.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Product data)
        {
            _context.Add(data);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Product data, Guid id)
        {
            if (data.Id != id)
                return BadRequest("Los identificadores del producto no coinciden");

            bool exists = await _context.Products.AnyAsync(p => p.Id == id);
            if (!exists)
                return NotFound();

            _context.Update(data);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool exists = await _context.Products.AnyAsync(p => p.Id == id);
            if (!exists)
                return NotFound();

            _context.Remove(new Product() { Id = id});
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
