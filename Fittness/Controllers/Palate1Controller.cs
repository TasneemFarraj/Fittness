﻿using Fittness.Data;
using Fittness.Data.Models;
using Fittness.Models;
using Fittness.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Fittness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Palate1Controller : ControllerBase
    {

        public Palate1Controller(AppDBContext db)
        {
            _db = db;
        }
        private readonly AppDBContext _db;

        //Get methods 
        [HttpGet]
        public async Task<ResponseStandardJsonApi> PalateCards()
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var Palate = await _db.Palates1.ToListAsync();
                if (Palate.Count()>0)
                {
                    apiResponse.Message = "Show Rows";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = Palate;
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "No Data";
                    apiResponse.Code = NotFound().StatusCode;
                    apiResponse.Result = new NullColumns[] { };
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.Code = BadRequest().StatusCode;
                apiResponse.Result = new NullColumns[] { };
            }

            return apiResponse;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PalateCards(int id)
        {
            var Palate = await _db.Palates1.SingleOrDefaultAsync(x => x.Id == id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {id} not exist!");
            }

            _db.SaveChanges();
            return Ok(Palate);
        }


        //Post method
        [HttpPost]
        public async Task<IActionResult> PalateCards([FromForm] mdlCrafts mdl)
        {
            using var stream = new MemoryStream();
            await mdl.Image.CopyToAsync(stream);


            var craft = new Palate1
            {
                Name = mdl.Name,
                Image = stream.ToArray()
            };
            await _db.Palates1.AddAsync(craft);
            await _db.SaveChangesAsync();
            return Ok(craft);
        }

        //Put method
        [HttpPut]
        public async Task<IActionResult> PalateCards(Palate1 palate)
        {
            var Palate = await _db.Palates1.SingleOrDefaultAsync(x => x.Id == palate.Id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {palate.Id} not exist!");
            }
            Palate.Name = palate.Name;
            _db.SaveChanges();
            return Ok(palate);
        }

        //Delete method
        [HttpDelete("id")]
        public async Task<IActionResult> RemovePalate(int id)
        {
            var Palate = await _db.Palates1.SingleOrDefaultAsync(x => x.Id == id);

            if (Palate == null)
            {
                return NotFound($"Palate Id {id} not exist!");
            }
            _db.Palates1.Remove(Palate);
            await _db.SaveChangesAsync();
            return Ok(Palate);
        }

        //Patch method
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePalatePatct
        ([FromBody] JsonPatchDocument<Palate1> palate, [FromRoute] int id)
        {
            var Palate = await _db.Palates1.SingleOrDefaultAsync(x => x.Id == id);

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


        

    

