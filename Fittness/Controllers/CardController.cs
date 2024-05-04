using Fittness.AutoMapper;
using Fittness.Data;
using Fittness.Data.Enum;
using Fittness.Data.Models;
using Fittness.Dtos.CredDtos;
using Fittness.Response;
using Fittness.UnitOfWork;
using Fittness.Upload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;


namespace Fittness.Controllers
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
        public async Task<ResponseStandardJsonApi> Getcard()
        {   
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
            var mapper = AutoMapperConfig.CreateMapper();
            var result = await _uOW.Card.GetListAsync();
            var data = mapper.Map<List<ReadCardDto>>(result);

        
                if (data is not null)
                {
                    apiResponse.Message = "Show Rows";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = data;
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


       [HttpGet(nameof(GetcardById))]
        public async Task<ResponseStandardJsonApi> GetcardById(int Id)
        {
            var mapper = AutoMapperConfig.CreateMapper();
            var result = await _uOW.Card.GetAsync(Id);
            var data = mapper.Map<ReadCardDto>(result);

            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                if (data is not null)
                {
                    apiResponse.Message = "Show Rows";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = data;
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


        [HttpPost(nameof(AddCard))]
        public async Task<ResponseStandardJsonApi> AddCard([FromForm]WriteCardDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();


            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<Card>(dto);
                if (dto.Img is not null)
                    data.Img = ImageUploader.Upload(dto.Img, FileTypeEnum.Image, "http://localhost:5266/");

                if (data is not null)
                {
                    await _uOW.Card.AddCard(data);
                    apiResponse.Message = "Show Rows";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = data;
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


    
    [HttpPut(nameof(UpdateCard))]
        public async Task<ResponseStandardJsonApi> UpdateCard([FromForm]WriteCardDto dto)
        {     var apiResponse = new ResponseStandardJsonApi();

        try
        {
            var mapper = AutoMapperConfig.CreateMapper();
            var data = mapper.Map<Card>(dto);
            if (dto.Img is not null)
                data.Img = ImageUploader.Upload(dto.Img, FileTypeEnum.Image, "http://localhost:5266/");
            await _uOW.Card.UpdateCard(data);
   
            if (data is not null)
                {
                apiResponse.Message = "Show Rows";
                apiResponse.Code = Ok().StatusCode;
                apiResponse.Success = true;
                apiResponse.Result = data;
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


        [HttpDelete(nameof(Removecard))]
        public async Task<ResponseStandardJsonApi> Removecard(int id)
        {
            await _uOW.Card.DeleteCard(id);

            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                if (id != 0)
                {
                    apiResponse.Message = "Show Rows";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = Ok("Delete");
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "No Data";
                    apiResponse.Code = NotFound().StatusCode;
                    apiResponse.Result = null;
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.Code = BadRequest().StatusCode;
                apiResponse.Result = null;
            }

            return apiResponse;

        }
    }
}