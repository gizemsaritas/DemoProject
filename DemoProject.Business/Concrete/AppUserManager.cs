using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.Business.Interfaces;
using DemoProject.DataAccess.Interfaces;
using DemoProject.DTO.Concrete.AppUser;
using DemoProject.Entities.Concrete;

namespace DemoProject.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;
        public AppUserManager(IGenericDal<AppUser> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
        public async Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto)
        {
            return await _genericDal.GetAsync(I => I.UserName == appUserLoginDto.UserName && I.Password == appUserLoginDto.Password);
        }
        public async Task<AppUser> FindByNameAsync(string userName)
        {
            return await _genericDal.GetAsync(I => I.UserName == userName);
        }

        public async Task AddUserAsync(AppUser appUser)
        {
            await _genericDal.AddAsync(appUser);
        }
    }
}
