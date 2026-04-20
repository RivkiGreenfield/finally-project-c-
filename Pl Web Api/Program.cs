
using AutoMapper;
using Bl;
using Bl.Api;
using Bl.Services;
using Dal.Api;
using Dal.Models;
using Dal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using Microsoft.Extensions.FileProviders;

namespace Pl_Web_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<BlCustomer, CustomersTbl>();

            //});
            //m = config.CreateMapper();

            var builder = WebApplication.CreateBuilder(args);

    //        builder.Services.AddDbContext<DbManager>(options =>
    //options.UseSqlServer("YourConnectionStringHere"));

    //        builder.Services.AddScoped<IVerificationCodes, VerificationCodesService>();
            //builder.Services.AddScoped<VerificationCodeBL>();

            // Add services to the container.
            builder.Services.AddSingleton<IBl, BlManager>();// new blmanager

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var MyAllowSpecificOrigins = "myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            var app = builder.Build();


         
            //var builder = WebApplication.CreateBuilder(args);

      
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            ///////
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("myAllowSpecificOrigins");
            /////
            ///


            var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(uploadsPath),
                RequestPath = "/Uploads"
            });
            app.MapControllers();
            app.UseStaticFiles();
            app.Run();


        }
    }
}
