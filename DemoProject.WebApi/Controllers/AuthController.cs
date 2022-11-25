using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoProject.Business.Interfaces;
using DemoProject.Business.Tools.JwtTools.Interfaces;
using DemoProject.DTO.Concrete.AppUser;
using DemoProject.Entities.Concrete;
using DevExpress.DirectX.Common.Direct2D;

namespace DemoProject.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;

        public AuthController(IAppUserService appUserService, IJwtService jwtService)
        {
            _appUserService = appUserService;
            _jwtService = jwtService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.CheckUserAsync(appUserLoginDto);
            if (user != null)
            {
                return Created("", _jwtService.GenerateJwt(user));
            }
            return BadRequest("username or password incorrect");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ActiveUser()
        {
            if (User.Identity != null)
            {
                var user = await _appUserService.FindByNameAsync(User.Identity.Name);
                if(user!= null) return Ok(new AppUserDto { Id = user.Id, Name = user.Name, SurName = user.Surname });
                else return BadRequest("can't find any user");
            }
            else return BadRequest("can't find any user");
        }

        //public async Task<IActionResult> SignIn(AppSignInDto appSignInDto)
        //{
        //    _appUserService.AddUserAsync(_mapper.Map<AppUser>(appSignInDto))
        //}
    }
}
