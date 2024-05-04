using Fittness.Authorization;
using Fittness.AutoMapper;
using Fittness.Data;
using Fittness.Data.Enum;
using Fittness.Data.Models;
using Fittness.Dtos.CredDtos;
using Fittness.Dtos.UserDtos;
using Fittness.Response;
using Fittness.UnitOfWork;
using Fittness.Upload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fittness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUOW _uOW;
        public IAuthentication<UserDto> Jwt { get; }
        public UserController( IUOW uOW, IAuthentication<UserDto> jwt)
        {
            _uOW = uOW;
            Jwt = jwt;
        }
        [HttpPost(nameof(AddUser))]
        public async Task<ResponseStandardJsonApi> AddUser([FromForm] WriteUserDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();


            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<User>(dto);
                if (data is not null)
                {
                    await _uOW.User.AddUser(data);
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
        [HttpPost(nameof(Login))]
        public async Task<ResponseStandardJsonApi> Login(LoginDto model)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {

                var Mapper = AutoMapperConfig.CreateMapper();
                var Data = Mapper.Map<User>(model);

                var Obj = await _uOW.User.LoginUser(Data);
                var NewData = Mapper.Map<UserDto>(Obj);
                if (Obj != null)
                {
                    var _userModel = Mapper.Map<UserDto>(Obj);
                    _userModel.Token = Jwt.GetJsonWebToken(_userModel);
                    NewData.Token = _userModel.Token;
                    apiResponse.Message = "Show Row";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = NewData;
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "UserName or Password uncorect ";
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
    }
}
