using Domain.Entities;

namespace Application.UserComands.GetUserComand
{
    public interface IGetUserComandHandler
    {
        Task<User> HandleAsync(GetUserComand comand, CancellationToken cancellationToken);
    }
}
