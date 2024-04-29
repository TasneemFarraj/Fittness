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
    public class CertificateController : ControllerBase
    {

        public CertificateController(AppDBContext db)
        {
            _db = db;
        }
        private readonly AppDBContext _db;

        //Get methods 
        [HttpGet]
        public async Task<IActionResult> CerImages()
        {
            var Cer = await _db.Certificates.ToListAsync();
            return Ok(Cer);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CerImages(int id)
        {
            var Cer = await _db.Certificates.SingleOrDefaultAsync(x => x.Id == id);

            if (Cer == null)
            {
                return NotFound($"Certificate Id {id} not exist!");
            }

            _db.SaveChanges();
            return Ok(Cer);
        }


        //Post method
        [HttpPost]
        public async Task<IActionResult> CerImages([FromForm] mdlCertif mdl)
        {
            using var stream = new MemoryStream();
            await mdl.Image.CopyToAsync(stream);


            var Cert = new Certificate
            {
                Image = stream.ToArray()
            };
            await _db.Certificates.AddAsync(Cert);
            await _db.SaveChangesAsync();
            return Ok(Cert);
        }

        //Put method
        [HttpPut]
        public async Task<IActionResult> CerImages(Certificate certificate)
        {
            var Cer = await _db.Certificates.SingleOrDefaultAsync(x => x.Id == certificate.Id);

            if (Cer == null)
            {
                return NotFound($"Cer Id {certificate.Id} not exist!");
            }
            _db.SaveChanges();
            return Ok(Cer);
        }

        //Delete method
        [HttpDelete("id")]
        public async Task<IActionResult> RemoveCerImages(int id)
        {
            var Cer = await _db.Certificates.SingleOrDefaultAsync(x => x.Id == id);

            if (Cer == null)
            {
                return NotFound($"Cer Id {id} not exist!");
            }
            _db.Certificates.Remove(Cer);
            await _db.SaveChangesAsync();
            return Ok(Cer);
        }

        //Patch method
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCerImagesPatct
        ([FromBody] JsonPatchDocument<Certificate> Cer, [FromRoute] int id)
        {
            var Certi = await _db.Certificates.SingleOrDefaultAsync(x => x.Id == id);

            if (Cer == null)
            {
                return NotFound($"Certificate Id {id} not exists");
            }
            Cer.ApplyTo(Certi);
            _db.SaveChanges();
            return Ok(Cer);

        }
    }
}


 