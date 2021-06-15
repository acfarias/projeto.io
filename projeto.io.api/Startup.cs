using acf.lib.bootstrap.Swagger;
using AcfLib.Filters;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using projeto.io.api.Mapeamentos;
using projeto.io.infra.crosscutting.ioc;

namespace projeto.io.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(cnf =>
            {
                cnf.Filters.Add(new ExceptionFilters());
            })
            .AddFluentValidation();

            services.AddConfiguracaoDeSwagger(Configuration);
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            services.RegistrarDependencias();
            services.AddMediatR(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseConfiguracoesDeSwagger(Configuration);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
