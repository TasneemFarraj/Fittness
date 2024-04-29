using Fittness.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Fittness.Data.Models;
using Fittness.Models;

namespace PickFitPor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager1 = userManager;
        }
        private readonly UserManager<AppUser> _userManager1;
        [HttpPost("[action]")]
        public async Task<IActionResult> RegisterNewUser(dtoNewUsercs user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                };
                IdentityResult result = await _userManager1.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    return Ok("success");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(dtologin login)
        {
            if (ModelState.IsValid)
            {
                AppUser? user = await _userManager1.FindByNameAsync(login.userName);
                if (user != null)
                {
                    if (await _userManager1.CheckPasswordAsync(user, login.Password))
                    {
                        return Ok("Token");
                    }
                    else
                    {
                        return Unauthorized();
                    }

                }
                else
                {
                    ModelState.AddModelError("", "User Name is invalid");
                }
            }
            return BadRequest(ModelState);
        }
    }
}