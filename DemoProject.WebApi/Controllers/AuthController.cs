using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoProject.Business.Interfaces;
using DemoProject.Business.Tools.JwtTools.Interfaces;
using DemoProject.DTO.Concrete.AppUser;
using DemoProject.Entities.Concrete;
using DevExpress.DirectX.Common.Direct2D;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DemoProject.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    public class AuthController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public AuthController(IAppUserService appUserService, IJwtService jwtService, IMapper mapper)
        {
            _appUserService = appUserService;
            _jwtService = jwtService;
            _mapper = mapper;
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
        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(AppSignInDto appSignInDto)
        {
            await _appUserService.AddUserAsync(_mapper.Map<AppUser>(appSignInDto));
            return Ok();
        }

    }
}
