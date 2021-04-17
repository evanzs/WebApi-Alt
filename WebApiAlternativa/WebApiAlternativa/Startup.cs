using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration,IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }      
       
        public void ConfigureServices(IServiceCollection services)
        {         

            services.AddControllers();

            //string de conexao com o banco
            string stringConexao = Configuration.GetConnectionString("Connection");
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

            // definindo migrations
            if (Environment.IsDevelopment())
            {
                MigrateDatabase(stringConexao);
            }

            //add swagger ao projeto
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API .NET 3.1 Para Crud de Categoria e Produto",
                    Version = "v1",
                    Description = "API feita para o teste de Backend da Aternativa Sistemas",
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi Alternativa Sistemas Teste");
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
        // metodo para add e definir migrations
        private void MigrateDatabase(string stringConexao)
        {
           try
           { 
                var cnx = new Microsoft.Data.SqlClient.SqlConnection(stringConexao);
                //iniciando evolve com a conexao
                //Nota: aqui seria melhor usar log
                var evolve = new Evolve.Evolve(cnx, msg => Console.WriteLine(msg))
                {
                    Locations = new[] { "db/migrations" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
           }
           catch(Exception ex)
           {
                Console.WriteLine(ex.Message);
                throw;
           }
        }
    }
}
