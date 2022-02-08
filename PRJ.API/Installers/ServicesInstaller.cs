using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PRJ.Repository;
using PRJ.Repository.Entity;
using PRJ.Service.Auth;
using PRJ.Service.RSA;
using PRJ.Service.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRJ.API.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRsaHelper, RsaHelper>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITransactionService, TransactionService>();
        }
    }
}
