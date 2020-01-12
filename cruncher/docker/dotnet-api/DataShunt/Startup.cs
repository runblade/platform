using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DataShunt.Models;

namespace DataShunt
{
    public class Startup
    {
        private string _dbConnectionString = null;
        private string _dbConnectionStringCMDLINE = null;
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration 
        { 
            get; 
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //Check configurations
            Console.WriteLine("Unit tests go here (startup)...");
            Console.WriteLine("Checking configuration variables...");
            //Check database connection string (from user-secrets)
            _dbConnectionString = Configuration["Database:ConnectionString"];
            //Check database connection string (from command line)
            _dbConnectionStringCMDLINE = Configuration["DBCONFIGSTRING"];
            services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(_dbConnectionStringCMDLINE));
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Should be changed to a unit test (check database is reachable)
            var resultA = string.IsNullOrEmpty(_dbConnectionString) ? "Null" : "Not Null";
            Console.WriteLine ($"DB Connection String: {resultA}");
            var resultB = string.IsNullOrEmpty(_dbConnectionStringCMDLINE) ? "Null" : "Not Null";
            Console.WriteLine ($"DB Connection String CMDLINE: {resultB}");
        }
    }
}