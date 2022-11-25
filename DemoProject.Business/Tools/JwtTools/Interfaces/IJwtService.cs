using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.DTO.Concrete.JWT;
using DemoProject.Entities.Concrete;

namespace DemoProject.Business.Tools.JwtTools.Interfaces
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser appUser);
    }
}
