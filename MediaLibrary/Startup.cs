using MediaLibrary.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.IdentityModel.Tokens;
using System.Text;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaLibrary.Models;

namespace MediaLibrary
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


            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("SuperUsers", p => p.RequireClaim("SuperUser", "True"));
            });


            services.AddAuthentication("MyAuthentication").AddJwtBearer("MyAuthentication", options =>
            {
                //options.ClaimsIssuer = Configuration["Tokens:Issuer"];
                //options.Audience = Configuration["Tokens:Audience"];
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidAudience = Configuration["Tokens:Audience"],
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                    ValidateLifetime = true
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("MediaLibraryCorsPolicy",
                    c => c.WithOrigins("*"));
            });


            services.AddDbContext<MediaLibraryContext>(opt => {
                opt.UseInMemoryDatabase("db1");
                // opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection");
            });





            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MediaLibraryContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //var context1 = app.ApplicationServices.GetService<MediaLibraryContext>();
            //TestData.AddTestData(context);
            context.Database.EnsureCreated();  // could move to isDevelopment block
            TestData.AddTestData(context);

            // this order may be wrong
            app.UseCors("MediaLibraryCorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            


            
        }
    }
}
