using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.Business.Concrete;
using DemoProject.Business.Interfaces;
using DemoProject.Business.Tools.JwtTools.Concrete;
using DemoProject.Business.Tools.JwtTools.Interfaces;
using DemoProject.Business.Tools.Validations;
using DemoProject.DataAccess.Concrete.Context;
using DemoProject.DataAccess.Concrete.Repositories;
using DemoProject.DataAccess.Interfaces;
using DemoProject.DTO.Concrete.AppUser;
using DemoProject.DTO.Concrete.JWT;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DemoProject.Business.Containers
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            #region Context

            services.AddDbContext<DemoProjectContext>();

            #endregion

            #region DependencyInjection

            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IJwtService, JwtManager>();

            #endregion

            #region Validation

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();

            #endregion
        }
    }
}
