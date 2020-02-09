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
using Xunit;
using Runblade.Cruncher.DataShunt.Models;
using Runblade.Cruncher.DataShunt.Controllers;

namespace Runblade.Cruncher.DataShunt
{
    public class Startup
    {
        private string _dbConnectionString = null;
        private string _dbConnectionStringCMDLINE = null;
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Console.WriteLine("Startup constructor called...");
        }

        public IConfiguration Configuration 
        { 
            get; 
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            Console.WriteLine("ConfigureServices called...");
            //Set database connection string (from user-secrets)
            _dbConnectionString = Configuration["Database:ConnectionString"];
            //Set database connection string (from command line)
            _dbConnectionStringCMDLINE = Configuration["DBCONFIGSTRING"];
            //For dependency injection
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

            //Basic debugging regarding database connection
            var resultA = string.IsNullOrEmpty(_dbConnectionString) ? "Null" : "Not Null";
            Console.WriteLine ($"DB Connection String: {resultA}");
            var resultB = string.IsNullOrEmpty(_dbConnectionStringCMDLINE) ? "Null" : "Not Null";
            Console.WriteLine ($"DB Connection String CMDLINE: {resultB}");

            //Basic unit testing regarding database connection
            CheckDBConnectionString();

            //Started up!
            Console.WriteLine("Reached end of Startup.");
        } 

        private string GetDBConnectionString()
        {
            return _dbConnectionStringCMDLINE;
        }    

        [Fact]
        private void CheckDBConnectionString()
        {
            Assert.NotNull(GetDBConnectionString());
        }           
    }
}