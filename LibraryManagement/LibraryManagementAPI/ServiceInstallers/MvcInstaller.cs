using FluentValidation.AspNetCore;
using LibraryManagementAPI.Data;
using LibraryManagementAPI.Domains;
using LibraryManagementAPI.Filters;
using LibraryManagementAPI.Options;
using LibraryManagementAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LibraryManagementAPI.ServiceInstallers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookService, BookService>();

            var jwtOptions = new JwtOptions();
            configuration.Bind(nameof(JwtOptions), jwtOptions);
            services.AddSingleton(jwtOptions);

            var readerOptions = new ReaderOptions();
            configuration.Bind(nameof(ReaderOptions), readerOptions);
            services.AddSingleton(readerOptions);

            services.AddScoped<IIdentityService, IdentityService>();

            services.AddControllers(options => options.Filters.Add<ValidationFilter>()).AddNewtonsoftJson(x =>
                 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Startup>());

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true,
            };
            services.AddSingleton(tokenValidationParameters);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.SaveToken = true;
                    x.TokenValidationParameters = tokenValidationParameters;
                });

            services.AddAutoMapper(typeof(Startup));
        }
    }
}
