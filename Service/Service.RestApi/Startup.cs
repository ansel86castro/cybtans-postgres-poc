using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FluentValidation.AspNetCore;
using Cybtans.AspNetCore;
using Cybtans.Entities.EntityFrameworkCore;
using Cybtans.Services.Extensions;

using Service.Domain.EntityFramework;
using Service.Services;

namespace Service.RestApi
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
            services.AddTransient<ServiceContextSeed>();

            services.AddHttpContextAccessor();

            AddSwagger(services);

            AddAuthentication(services);

            #region Cors

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                       builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                        .WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod();                        
                    });
            });

            #endregion

            services.AddDbContext<ServiceContext>(
                builder => builder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("Service.RestApi")));

            services
            .AddUnitOfWork<ServiceContext>()
            .AddRepositories();

            services.AddAutoMapper(typeof(ServiceStub));

            services
            .AddControllers(options => options.Filters.Add<HttpResponseExceptionFilter>())
            .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining(typeof(ServiceStub)));          

            services.AddCybtansServices(typeof(ServiceStub).Assembly);         
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
             EfAsyncQueryExecutioner.Setup();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandlingMiddleware();
            }

            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Service V1");
                c.EnableFilter();
                c.EnableDeepLinking();
                c.ShowCommonExtensions();  
                
                c.OAuthClientId("swagger");
                c.OAuthClientSecret(Configuration.GetValue<string>("Identity:Secret"));
                c.OAuthAppName("Service");
                c.OAuthUsePkce();
            });
            
             app.UseReDoc(c =>
            {
                c.RoutePrefix = "docs";
                c.SpecUrl("/swagger/v1/swagger.json");
                c.DocumentTitle = "Service API";
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Service", Version = "v1" });
                c.OperationFilter<SwachBuckleOperationFilters>();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });


                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{Configuration.GetValue<string>("Identity:Swagger")}/connect/authorize"),
                            TokenUrl = new Uri($"{Configuration.GetValue<string>("Identity:Swagger")}/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                { "api", "Service API" }
                            }
                        }
                    }
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                             Reference = new OpenApiReference
                             {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "oauth2"
                             }
                        },
                        new string[0]
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[0]
                    }
                });
            });
        }

        void AddAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Authority = Configuration.GetValue<string>("Identity:Authority");
                options.Audience = $"{options.Authority}/resources";                 
                options.RequireHttpsMetadata = false;                    
                options.SaveToken = true;               
            });

            services.AddAuthorization();
		}
    }
}
