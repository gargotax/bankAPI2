using Application.CreateUserComand;
using Application.DeleteUserComand;
using Application.GetUserComand;
using Application.UpdateUserComand;
using Domain.Repos;
using Infrastructure;

namespace BankApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICreateUserComandHandler, CreateUserComandHandler>();
            builder.Services.AddScoped<IGetUserComandHandler, GetUserComandHandler>();
            builder.Services.AddScoped<IDeleteUserComandHandler, DeleteUserComandHandler>();
            builder.Services.AddScoped<IUpdateUserComandHandler, UpdateUserComandHandler>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
