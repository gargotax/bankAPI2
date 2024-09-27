using Application.AccountComands.CreateAccountComand;
using Application.AccountComands.DeleteAccountComand;
using Application.AccountComands.GetAccountComand;
using Application.AccountComands.UpdateAccountComand;
using Application.TransactionComands;
using Application.UserComands.CreateUserComand;
using Application.UserComands.DeleteUserComand;
using Application.UserComands.GetUserComand;
using Application.UserComands.UpdateUserComand;
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
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<ICreateAccountComandHandler, CreateAccountComandHandler>();
            builder.Services.AddScoped<IGetAccountComandHandler, GetAccountComandHandler>();
            builder.Services.AddScoped<IDeleteAccountComandHandler, DeleteAccountComandHandler>();
            builder.Services.AddScoped<IUpdateAccountComandHandler, UpdateAccountComandHandler>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<ICreateTransactionComandHandler, CreateTransactionComandHandler>();

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
