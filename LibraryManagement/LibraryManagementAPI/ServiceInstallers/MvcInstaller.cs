using FluentValidation.AspNetCore;
using LibraryManagementAPI.Data;
using LibraryManagementAPI.Domains;
using LibraryManagementAPI.Filters;
using LibraryManagementAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementAPI.ServiceInstallers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookService, BookService>();

            services.AddControllers(options => options.Filters.Add<ValidationFilter>()).AddNewtonsoftJson(x =>
                 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddAutoMapper(typeof(Startup));
        }
    }
}
