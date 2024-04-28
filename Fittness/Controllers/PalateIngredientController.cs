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
    public class PalateIngredientController : ControllerBase
    {
        public PalateIngredientController(AppDBContext db)
        {
            _db = db;
        }
        private readonly AppDBContext _db;

        //Get methods 
        [HttpGet]
        public async Task<IActionResult> PalateIngrads()
        {
            var Palate = await _db.PalateIngredients.ToListAsync();
            return Ok(Palate);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PalateIngrads(int id)
        {
            var Palate = await _db.PalateIngredients.SingleOrDefaultAsync(x => x.Id == id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {id} not exist!");
            }

            _db.SaveChanges();
            return Ok(Palate);
        }


        //Post method
        [HttpPost]
        public async Task<IActionResult> PalateIngrads(string item_1, string item_2, string item_3, string item_4, string item_5, string item_6, string item_7)
        {
            PalateIngredient palate = new()
            {
                item_1=item_1, 
                item_2=item_2,
                item_3=item_3,
                item_4=item_4,
                item_5=item_5,
                item_6=item_6,
                item_7=item_7,
            };

            await _db.PalateIngredients.AddAsync(palate);
            _db.SaveChanges();
            return Ok(palate);
        }

        //Put method
        [HttpPut]
        public async Task<IActionResult> PalateIngrads(PalateIngredient palate)
        {
            var Palate = await _db.PalateIngredients.SingleOrDefaultAsync(x => x.Id == palate.Id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {palate.Id} not exist!");
            }
            _db.SaveChanges();
            return Ok(palate);
        }

        //Delete method
        [HttpDelete("id")]
        public async Task<IActionResult> RemovePalateIngrads(int id)
        {
            var Palate = await _db.PalateIngredients.SingleOrDefaultAsync(x => x.Id == id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {id} not exist!");
            }
            _db.PalateIngredients.Remove(Palate);
            await _db.SaveChangesAsync();
            return Ok(Palate);
        }

        //Patch method
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePalateIngradsPatct
        ([FromBody] JsonPatchDocument<PalateIngredient> palate, [FromRoute] int id)
        {
            var Palate = await _db.PalateIngredients.SingleOrDefaultAsync(x => x.Id == id);

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
