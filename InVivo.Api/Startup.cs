using InVivo.Api.Security;
using InVivo.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace InVivo.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        //For use JWT Authentication
        private const string ISSUER = "cr5151t3";
        private const string AUDIENCE = "c6bbbb645024";
        private const string SECRET_KEY = "cr5151t3-5727-4d15-b787-c6bbbb645024";

        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));



        //Adicionado para poder incluir arquivo appsettings json
        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // 1. Polices
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            // 2. CORS
            services.AddCors();

            // 3. Claims
            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireClaim("InVivo", "User"));
                options.AddPolicy("Admin", policy => policy.RequireClaim("InVivo", "Admin"));
            });

            // 4. Token JWT
            services.Configure<TokenOptions>(options =>
            {
                options.Issuer = ISSUER;
                options.Audience = AUDIENCE;
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });


            //Resolve as dependências (Dependence Injections)
            DependenceResolver.Register(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 1. Token Parameters
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = ISSUER,

                ValidateAudience = true,
                ValidAudience = AUDIENCE,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            // 2. JWT Bearer
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });

            // 3. CORS
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();

            });

            // 4. Use MVC
            app.UseMvc();

            // 5. DB Connection Strings
            Runtime.ConnectionString = Configuration.GetConnectionString("CnnStr");
        }
    }
}
