using Application.UserComands.GetUserComand;

namespace Application.AccountComands.CreateAccountComand
{
    public interface ICreateAccountComandHandler
    {
        Task<Guid> HandleAsync(CreateAccountComand comand, GetUserComand userComand, CancellationToken cancellationToken);
    }
}
