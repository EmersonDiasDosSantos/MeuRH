using Domain.RepositoryInterfaces;
using Infrastructure.CrossCutting.Data.Context;
using Infrastructure.CrossCutting.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Extension;

namespace Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatorWithValidation();

            builder.Services.AddTransient<IUserRepository, UserRepository>();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();



            app.Run();
        }
    }
}
