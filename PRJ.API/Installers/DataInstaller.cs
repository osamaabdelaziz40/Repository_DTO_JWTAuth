using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PRJ.API.Filters;
using PRJ.Repository.Entity;
using PRJ.Service.AutoMapper;
using PRJ.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PRJ.API.Installers
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<MainContext>(opts => opts.UseSqlServer(ConfigurationStrings.AppConnectionString));
            services.AddControllers();
            services.AddCors();

            var mapperConfiguration = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);


            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));

                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    return new BadRequestObjectResult(new RequestValidationFilter(context))
                    {
                        StatusCode = 400
                    };
                };
            });
        }
    }
}
