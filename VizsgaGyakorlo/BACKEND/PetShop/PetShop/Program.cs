
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using Scalar.AspNetCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PetShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<PetDbContext>(opt => opt.UseSqlite("Data Source =.\\Data\\PetShop.db"));

            var app = builder.Build();

            //Data Source =.\Data\PetShop.db

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();

                app.MapGet("/", () => Results.Redirect("/scalar"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
