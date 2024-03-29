using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Sp_medical_group_tarde
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                // Adiciona o servi�o dos Controllers
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                // Ignora os loopings nas consultas
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // Ignora valores nulos ao fazer jun��es nas consultas
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            // Adiciona o servi�o do Swagger
            // https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:19002", "http://localhost:19006")
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod();
                    }
                );
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sp_medical_group_tarde.webApi", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services
                // Define a forma de autentica��o
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // define que o issuer ser� validado
                        ValidateIssuer = true,

                        // define que o audience ser� validado
                        ValidateAudience = true,

                        // define que o tempo de vida ser� validado
                        ValidateLifetime = true,

                        // forma de criptografia e a chave de autentica��o
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmg-chave-autenticacao")),

                        // verifica o tempo de expira��o do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // define o nome da issuer, de onde est� vindo
                        ValidIssuer = "Sp_medical_group_tarde.webApi",

                        // define o nome da audience, para onde est� indo
                        ValidAudience = "Sp_medical_group_tarde.webApi"
                    };
                });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sp_medical_group_tarde.webApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            // Habilita autentica��o
            app.UseAuthentication();

            // Habilita autoriza��o
            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                // Define o mapeamento dos Controllers
                endpoints.MapControllers();
            });
        }
    }
}
