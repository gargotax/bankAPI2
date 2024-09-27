using Domain.Entities;

namespace Application.AccountComands.GetAccountComand
{
    public interface IGetAccountComandHandler
    {
        Task<Account> HandleAsync(GetAccountComand comand, CancellationToken cancellationToken);
    }
}
