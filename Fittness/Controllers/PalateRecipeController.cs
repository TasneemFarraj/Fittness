using Fittness.Data.Models;
using Fittness.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fittness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalateRecipeController : ControllerBase
    {
        public PalateRecipeController(AppDBContext db)
        {
            _db = db;
        }
        private readonly AppDBContext _db;

        //Get methods 
        [HttpGet]
        public async Task<IActionResult> PalateRecipes()
        {
            var Palate = await _db.PalateRecipes.ToListAsync();
            return Ok(Palate);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PalateRecipes(int id)
        {
            var Palate = await _db.PalateRecipes.SingleOrDefaultAsync(x => x.Id == id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {id} not exist!");
            }

            _db.SaveChanges();
            return Ok(Palate);
        }


        //Post method
        [HttpPost]

        public async Task<IActionResult> PalateRecipes(string Preparatio_time, string Cooking_time, int NumberOf_people, string Difficulty_level)
        {
            PalateRecipe palate = new()
            {
                PreparationTime = Preparatio_time,
                CookingTime = Cooking_time,
                NumberOfPeople = NumberOf_people,
                DifficultyLevel = Difficulty_level,
            };
            await _db.PalateRecipes.AddAsync(palate);
            _db.SaveChanges();
            return Ok(palate);
        }

        //Put method
        [HttpPut]
        public async Task<IActionResult> PalateRecipes(PalateRecipe palate)
        {
            var Palate = await _db.PalateRecipes.SingleOrDefaultAsync(x => x.Id == palate.Id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {palate.Id} not exist!");
            }
            _db.SaveChanges();
            return Ok(palate);
        }

        //Delete method
        [HttpDelete("id")]
        public async Task<IActionResult> RemovePalateRecipes(int id)
        {
            var Palate = await _db.PalateRecipes.SingleOrDefaultAsync(x => x.Id == id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {id} not exist!");
            }
            _db.PalateRecipes.Remove(Palate);
            await _db.SaveChangesAsync();
            return Ok(Palate);
        }

        //Patch method
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePalateRecipesPatct
        ([FromBody] JsonPatchDocument<PalateRecipe> palate, [FromRoute] int id)
        {
            var Palate = await _db.PalateRecipes.SingleOrDefaultAsync(x => x.Id == id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {id} not exists");
            }
            palate.ApplyTo(Palate);
            _db.SaveChanges();
            return Ok(Palate);

        }
    }
}
