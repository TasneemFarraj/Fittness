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
    public class PalatePrepareController : ControllerBase
    {
        public PalatePrepareController(AppDBContext db)
        {
            _db = db;
        }
        private readonly AppDBContext _db;

        //Get methods 
        [HttpGet]
        public async Task<IActionResult> HowPalate()
        {
            var Palate = await _db.PalatePrepares.ToListAsync();
            return Ok(Palate);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> HowPalate (int id)
        {
            var Palate = await _db.PalatePrepares.SingleOrDefaultAsync(x => x.Id == id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {id} not exist!");
            }

            _db.SaveChanges();
            return Ok(Palate);
        }


        //Post method
        [HttpPost]
        public async Task<IActionResult> HowPalate (string step_1, string step_2, string step_3, string step_4, string step_5, string step_6, string step_7)
        {
            PalatePrepare palate = new()
            {
                step_1=step_1,
                step_2=step_2, 
                step_3=step_3, 
                step_4=step_4, 
                step_5=step_5,
                step_6=step_6, 
                step_7=step_7,

            };

            await _db.PalatePrepares.AddAsync(palate);
            _db.SaveChanges();
            return Ok(palate);
        }

        //Put method
        [HttpPut]
        public async Task<IActionResult> HowPalate (PalateIngredient palate)
        {
            var Palate = await _db.PalatePrepares.SingleOrDefaultAsync(x => x.Id == palate.Id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {palate.Id} not exist!");
            }
            _db.SaveChanges();
            return Ok(palate);
        }

        //Delete method
        [HttpDelete("id")]
        public async Task<IActionResult> RemoveHowPalate(int id)
        {
            var Palate = await _db.PalatePrepares.SingleOrDefaultAsync(x => x.Id == id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {id} not exist!");
            }
            _db.PalatePrepares.Remove(Palate);
            await _db.SaveChangesAsync();
            return Ok(Palate);
        }

        //Patch method
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateHowPalatePatct
        ([FromBody] JsonPatchDocument<PalatePrepare> palate, [FromRoute] int id)
        {
            var Palate = await _db.PalatePrepares.SingleOrDefaultAsync(x => x.Id == id);

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

