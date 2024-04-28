using Azure;
using Fittness.Data;
using Fittness.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fittness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public CategoriesController(AppDBContext db)
        {
            _db = db;
        }
        private readonly AppDBContext _db;
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var cats = await _db.Categories.ToListAsync();
            return Ok(cats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategories(int id)
        {
            var cats = await _db.Categories.ToListAsync();
            return Ok(cats);

         
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == category.Id);

            if (c == null)
            {
                return NotFound($"Category Id {category.Id} not exists");
            }
            c.Name = category.Name;
            _db.SaveChanges();
            return Ok(c);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);

            if (c == null)
            {
                return NotFound($"Category Id {id} not exists");
            }
            _db.Categories.Remove(c);
            await _db.SaveChangesAsync();
            return Ok(c);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCategoryPatct
            ([FromBody] JsonPatchDocument<Category> category, [FromRoute] int id)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);

            if (c == null)
            {
                return NotFound($"Category Id {id} not exists");
            }
            category.ApplyTo(c);

            _db.SaveChanges();
            return Ok(c);
        }
    }
}