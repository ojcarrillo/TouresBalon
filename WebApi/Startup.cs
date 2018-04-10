﻿using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using WebApi.Models;
using WebApi.Persistence;

namespace WebApi
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
            var pathProductImages = Path.Combine(Directory.GetCurrentDirectory(), "productImages");
            if (!Directory.Exists(pathProductImages))
            {
                try
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathProductImages);
                }
                finally { }
            }
            services.AddCors();
            services.AddScoped<IRepository, EfRepository>();
            services.AddDbContext<EFDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EASDatabase")));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder =>
                builder
                       .AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
                       
            app.UseMvc();
        }
    }
}