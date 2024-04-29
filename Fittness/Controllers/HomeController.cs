using Fittness.Data;
using Fittness.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fittness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController(AppDBContext db)
        {
            _db = db;
        }
        private readonly AppDBContext _db;

        [HttpGet]
        public async Task<IActionResult> GetHome()
        {
            var Home = await _db.Homes.ToListAsync();
            return Ok(Home);

        }
        [HttpPost]
        public async Task<IActionResult> AddHome(string Home)
        {
            Home h = new() { Name = Home };
            await _db.Homes.AddAsync(h);
            _db.SaveChanges();
            return Ok(h);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHome(Home Homes)
        {
            var h = await _db.Homes.SingleOrDefaultAsync(h => h.Id == Homes.Id);
            if (h == null)
            {
                return NotFound($"Home ");
            }
            h.Name = Homes.Name;
            _db.SaveChanges();
            return Ok(h);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> RemoveHome(int id)
        {
            var c = await _db.Homes.SingleOrDefaultAsync(x => x.Id == id);

            if (c == null)
            {
                return NotFound($"Home Id {id} not exists");
            }
            _db.Homes.Remove(c);
            _db.SaveChanges();
            return Ok(c);
        }
    }
}


