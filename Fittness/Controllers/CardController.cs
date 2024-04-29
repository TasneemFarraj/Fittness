using Fittness.Data;
using Fittness.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace PickFitPor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        public CardController(AppDBContext db)
        {
            _db = db;
        }
        private readonly AppDBContext _db;

        [HttpGet]
        public async Task<IActionResult> Getcard()
        {
            var card = await _db.Cards.ToListAsync();
            return Ok(card);
        }
        [HttpPost]
        public async Task<IActionResult> AddCard( string Name, string Specialty, string Phone, string Addrres, string Rating,string img,string Email,string WorkingDay)
        {
            var card = new Card
            { 
               Name = Name,
               Specialty = Specialty,
                Phone = Phone,
                Addrres = Addrres,
                Rating = Rating,
                Img = img,
                Email = Email,
                WorkingDay = WorkingDay
            };
            await _db.Cards.AddAsync(card);
            _db.SaveChanges();
            return Ok(card);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCard(Card Cards)
        {
            var ccard = await _db.Cards.SingleOrDefaultAsync(ccard => ccard.Id == ccard.Id);
            if (ccard == null)
            {
                return NotFound($"Cards");
            }
          
            ccard.Name = Cards.Name;
            ccard.Specialty = Cards.Specialty;
            ccard.Phone = Cards.Phone;
            ccard.Addrres = Cards.Addrres;
            ccard.Rating = Cards.Rating;
            ccard.Img=ccard.Img;
            ccard.Email = ccard.Email;
            ccard.WorkingDay = ccard.WorkingDay;

            _db.SaveChanges();
            return Ok(ccard);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Removecard(int id)
        {
            var c = await _db.Cards.SingleOrDefaultAsync(x => x.Id == id);

            if (c == null)
            {
                return NotFound($"Card Id {id} not exist");
            }
            _db.Cards.Remove(c);
            _db.SaveChanges();
            return Ok(c);
        }
    }
}
