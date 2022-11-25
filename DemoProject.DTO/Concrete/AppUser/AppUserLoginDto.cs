using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.DTO.Interfaces;

namespace DemoProject.DTO.Concrete.AppUser
{
    public class AppUserLoginDto:IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
