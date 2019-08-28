using MicroService.PhoneBook.Data;
using MicroService.PhoneBook.Repository;
using MicroService.PhoneBook.Repository.Model;
using MicroService.PhoneBook.Service;
using MicroService.PhoneBook.Service.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace MicroService.PhoneBook
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
            services.AddDbContext<DataContext>(opt =>
                opt.UseInMemoryDatabase("PhoneBook"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new Info { Title = "microservice.phonebook", Version = "V1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(GetXmlCommentPath(typeof(MicroService.PhoneBook.Service.Domain.Entry)));
                c.IncludeXmlComments(xmlPath);

            });
            services.AddScoped<IPhoneBookService, PhoneBookService>();
            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();

        }
        private static string GetXmlCommentPath(Type assemblyName) => Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetAssembly(assemblyName).GetName().Name}.xml");


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
            });
            app.UseMvc();
        }
    }
}
