using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DemoProject.Entities.Concrete
{
    public class AppUser:IdentityUser,ITable
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
