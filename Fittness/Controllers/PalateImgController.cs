using Fittness.Data.Models;
using Fittness.Data;
using Fittness.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fittness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalateImgController : ControllerBase
    {

        public PalateImgController(AppDBContext db)
        {
            _db = db;
        }
        private readonly AppDBContext _db;

        //Get methods 
        [HttpGet]
        public async Task<IActionResult> PalateImages()
        {
            var Palate = await _db.PalatesImg.ToListAsync();
            return Ok(Palate);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PalateImages(int id)
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
        public async Task<IActionResult> PalateImages([FromForm] mdlImg mdl)
        {
            using var stream = new MemoryStream();
            await mdl.Image.CopyToAsync(stream);


            var craft = new PalateImg
            {
                Image = stream.ToArray()
            };
            await _db.PalatesImg.AddAsync(craft);
            await _db.SaveChangesAsync();
            return Ok(craft);
        }

        //Put method
        [HttpPut]
        public async Task<IActionResult> PalateImages(PalateImg palate)
        {
            var Palate = await _db.Palates1.SingleOrDefaultAsync(x => x.Id == palate.Id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {palate.Id} not exist!");
            }
            _db.SaveChanges();
            return Ok(palate);
        }

        //Delete method
        [HttpDelete("id")]
        public async Task<IActionResult> RemovePalateImages(int id)
        {
            var Palate = await _db.PalatesImg.SingleOrDefaultAsync(x => x.Id == id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {id} not exist!");
            }
            _db.PalatesImg.Remove(Palate);
            await _db.SaveChangesAsync();
            return Ok(Palate);
        }

        //Patch method
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePalateImagesPatct
        ([FromBody] JsonPatchDocument<PalateImg> palate, [FromRoute] int id)
        {
            var Palate = await _db.PalatesImg.SingleOrDefaultAsync(x => x.Id == id);

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



 
