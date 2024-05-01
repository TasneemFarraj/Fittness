using Fittness.AutoMapper;
using Fittness.Data;
using Fittness.Data.Enum;
using Fittness.Data.Models;
using Fittness.Dtos.CredDtos;
using Fittness.UnitOfWork;
using Fittness.Upload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace PickFitPor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly IUOW _uOW;
        public CardController(AppDBContext db, IUOW uOW)
        {
            _db = db;
            _uOW = uOW;
        }


        [HttpGet(nameof(Getcard))]
        public async Task<IActionResult> Getcard()
        {
            var mapper = AutoMapperConfig.CreateMapper();
            var result = await _uOW.Card.GetListAsync();
            var data = mapper.Map<List<ReadCardDto>>(result);
            return Ok(data);

        }
        [HttpGet(nameof(GetcardById))]
        public async Task<IActionResult> GetcardById(int Id)
        {
            var mapper = AutoMapperConfig.CreateMapper();
            var result = await _uOW.Card.GetAsync(Id);
            var data = mapper.Map<ReadCardDto>(result);
            return Ok(data);

        }
        [HttpPost(nameof(AddCard))]
        public async Task<IActionResult> AddCard([FromForm]WriteCardDto dto)
        {
            var mapper = AutoMapperConfig.CreateMapper();
            var data = mapper.Map<Card>(dto);
            if (dto.Img is not null)
                data.Img = ImageUploader.Upload(dto.Img, FileTypeEnum.Image, "http://localhost:5266/");
            await _uOW.Card.AddCard(data);
            return Ok(data);
        }
        [HttpPut(nameof(UpdateCard))]
        public async Task<IActionResult> UpdateCard([FromForm]WriteCardDto dto)
        {
            var mapper = AutoMapperConfig.CreateMapper();
            var data = mapper.Map<Card>(dto);
            if (dto.Img is not null)
                data.Img = ImageUploader.Upload(dto.Img, FileTypeEnum.Image, "http://localhost:5266/");
            await _uOW.Card.UpdateCard(data);
            return Ok("Update");
        }
        [HttpDelete(nameof(Removecard))]
        public async Task<IActionResult> Removecard(int id)
        {
            await _uOW.Card.DeleteCard(id);
            return Ok("Delete");
        }
    }
}
