using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.DTO.Concrete.AppUser;
using DemoProject.Entities.Concrete;

namespace DemoProject.Business.Interfaces
{
    public interface IAppUserService
    {
        Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto);
        Task<AppUser> FindByNameAsync(string userName);
        Task AddUserAsync(AppUser appUser);
    }
}
