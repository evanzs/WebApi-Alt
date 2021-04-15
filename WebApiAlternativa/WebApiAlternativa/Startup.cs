using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApiAlternativa.Context;
using WebApiAlternativa.Data.Repository.Generic;
using WebApiAlternativa.Data.Bussiness;
using WebApiAlternativa.Data.Business.Implementaions;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

namespace WebApiAlternativa
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string stringConexao = Configuration.GetConnectionString("Connection");
            services.AddControllers();

            services.AddDbContext<AlternativaContext>(c =>
            {
                try
                {
                    c.UseSqlServer(stringConexao);
                }
                catch (Exception e)
                {
                    var message = e.Message;
                }

            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebApi Alternativa Sistema Teste",
                    Version = "v1",
                    Description = "API feita para testa de BackEnd da Aternativa Sistemas",
                    Contact =  new OpenApiContact
                    {
                        Name = "Evandro Fernandes",
                        Url = new Uri ("https://github.com/evanzs")

                    }
                });
            });

            //dependencias
            services.AddScoped<ICategoryBusiness, CategoryBusiness>();
            services.AddScoped<IProductBusiness, ProductBusiness>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                //definindo PATH para o swagger
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi Alternativa Sistema Teste");
            });

            //Definindo configuracoes da pagina
            var option = new RewriteOptions();
            //redirencionando para pagina do swagger
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
