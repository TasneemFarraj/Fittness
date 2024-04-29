using Fittness.Data.Models;
using Fittness.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fittness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrequentlyquestionsController : ControllerBase
    {
        public FrequentlyquestionsController(AppDBContext db)
        {
            _db = db;
        }
        private readonly AppDBContext _db;

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            var Frequentlie = await _db.Frequently_questions.ToListAsync();
            return Ok(Frequentlie);

        }
        [HttpPost]
        public async Task<IActionResult> AddQuestions(string Questions, string Answer)
        {
            var Frequently_questions = new Frequently_question
            {
                Question = Questions,
                Answer = Answer,

            };
            await _db.Frequently_questions.AddAsync(Frequently_questions);
            _db.SaveChanges();
            return Ok(Frequently_questions);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateQuestions(Frequently_question Questions)
        {
            var Questionss = await _db.Frequently_questions.SingleOrDefaultAsync(Frequently_questions => Frequently_questions.Id == Frequently_questions.Id);
            if (Questionss == null)
            {
                return NotFound($"Questions");
            }

            Questionss.Question = Questions.Question;
            Questionss.Answer = Questions.Answer;
            _db.SaveChanges();
            return Ok(Questionss);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveQuestions(int id)
        {
            var Frequentlie = await _db.Frequently_questions.SingleOrDefaultAsync(x => x.Id == id);
            if (Frequentlie == null)
            {
                return NotFound($"questions with Id {id} not found.");
            }
            _db.Frequently_questions.Remove(Frequentlie);
            await _db.SaveChangesAsync();
            return Ok(Frequentlie);
        }
    }
}

