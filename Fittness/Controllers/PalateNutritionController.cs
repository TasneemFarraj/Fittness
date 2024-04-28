using Fittness.Data.Models;
using Fittness.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Fittness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalateNutritionController : ControllerBase
    {
        public PalateNutritionController(AppDBContext db)
        {
            _db = db;
        }
        private readonly AppDBContext _db;

        //Get methods 
        [HttpGet]
        public async Task<IActionResult> PalatePerServing()
        {
            var Palate = await _db.PalateNutritions.ToListAsync();
            return Ok(Palate);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PalatePerServing(int id)
        {
            var Palate = await _db.PalatesImg.SingleOrDefaultAsync(x => x.Id == id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {id} not exist!");
            }

            _db.SaveChanges();
            return Ok(Palate);
        }


        //Post method
        [HttpPost]
        public async Task<IActionResult> PalatePerServing(string Fats, string protein, string carbohydrates, string calories)
        {
            PalateNutrition palate = new()
            {
            Fats= Fats,
            protein= protein,
            carbohydrates=carbohydrates,
            calories = calories,
            };

            await _db.PalateNutritions.AddAsync(palate);
            _db.SaveChanges();
            return Ok(palate);
        }

        //Put method
        [HttpPut]
        public async Task<IActionResult> PalatePerServing(PalateNutrition palate)
        {
            var Palate = await _db.PalateNutritions.SingleOrDefaultAsync(x => x.Id == palate.Id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {palate.Id} not exist!");
            }
            _db.SaveChanges();
            return Ok(palate);
        }

        //Delete method
        [HttpDelete("id")]
        public async Task<IActionResult> RemovePalatePerServing(int id)
        {
            var Palate = await _db.PalateNutritions.SingleOrDefaultAsync(x => x.Id == id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {id} not exist!");
            }
            _db.PalateNutritions.Remove(Palate);
            await _db.SaveChangesAsync();
            return Ok(Palate);
        }

        //Patch method
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePalatePerServingPatct
        ([FromBody] JsonPatchDocument<PalateNutrition> palate, [FromRoute] int id)
        {
            var Palate = await _db.PalateNutritions.SingleOrDefaultAsync(x => x.Id == id);

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

