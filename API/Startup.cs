using System;
using Application.Core;
using Application.Queries.BusSchedules;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
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

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<FacultyDBContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(typeof(GetAllBusSchedules.Handler).Assembly);
            services.AddMediatR(typeof(UpdateBusScheduleInformation.Handler).Assembly);
            services.AddMediatR(typeof(UpdateBusScheduleSlots.Handler).Assembly);

            services.AddSingleton<MongoDbContext>();

            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

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
