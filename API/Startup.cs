using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Faculties;
using Application.Levels;
using Application.Queries.BusSchedules;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Persistence;

namespace API
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

            services.AddControllers();
            services.AddDbContext<FacultyDBContext>(opt =>
                opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(typeof(ListFaculties.Query).Assembly);
            services.AddMediatR(typeof(ListFacultiesForUser.Handler).Assembly);
            services.AddMediatR(typeof(GetAllBusSchedules.Handler).Assembly);
            services.AddMediatR(typeof(UpdateBusScheduleInformation.Handler).Assembly);
            services.AddMediatR(typeof(UpdateBusScheduleSlots.Handler).Assembly);

            services.AddSingleton<MongoDbContext>();

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            //services.AddSingleton<MongoClientBase>();

            services.AddCors(opt =>
           {
               opt.AddPolicy("CorsPolicy", policy =>
               {
                   policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials().WithOrigins("http://localhost:3000");
               });
           });

            services.AddControllers().AddNewtonsoftJson(options =>
           options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
