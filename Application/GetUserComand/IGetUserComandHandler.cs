using Domain.Entities;

namespace Application.GetUserComand
{
    public interface IGetUserComandHandler
    {
        Task<User> HandleAsync(GetUserComand comand, CancellationToken cancellationToken); 
    }
}
