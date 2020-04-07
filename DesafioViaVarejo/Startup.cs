using DesafioViaVarejo.ApplicationService;
using DesafioViaVarejo.Domain.AppServices;
using DesafioViaVarejo.Domain.AppServices.Authentication;
using DesafioViaVarejo.Domain.Entities;
using DesafioViaVarejo.Domain.Notification.Interfaces;
using DesafioViaVarejo.Domain.Services.Interface;
using DesafioViaVarejo.Infra.ExternalServices.Tax;
using DesafioViaVarejo.Infra.Repository;
using DesafioViaVarejo.Infra.Services.Installment;
using DesafioViaVarejo.Infra.Services.Notify;
using DesafioViaVarejo.Infra.Services.Product;
using DesafioViaVarejo.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;

namespace DesafioViaVarejo.API
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Desafio Via Varejo",
                    Description = "Desafio: Criar um endpoint para que possamos simular a compra de um produto, deve retornar uma lista de parcelas, acrescidas de juros com base na taxa SELIC de 1.15% ao mês (se possível consultar a taxa em tempo real), somente quando o número de parcelas for superior a 06 (seis) parcelas.",
                    Contact = new OpenApiContact() { Name = "Gabriel Milaré de Paula - 11 947240633", Email = "gmilare@outlook.com" },
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Autenticação JWT, para autenticar insira o valor
                    do token como o de examplo: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            #region DI

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IInstallmentService, InstallmentService>();
            services.AddScoped<IProductApplicationService, ProductApplicationService>();
            services.AddScoped<IAuthenticationApplicationService, AuthenticationApplicationService>();
            services.AddScoped<INotification, Notificador>();
            services.AddScoped<ITaxService, TaxService>();
            services.AddScoped<IUserRepository, UserRepository>();

            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Via Verejo");
            });

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
