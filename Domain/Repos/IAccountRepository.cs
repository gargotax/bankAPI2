using Domain.Entities;

namespace Domain.Repos
{
    public interface IAccountRepository
    {
        Task<Guid> CreateAccount(Account account, CancellationToken cancellationToken);
        Task<Account?> GetAccountById(Guid id, CancellationToken cancellationToken);
        Task DeleteAccount(Guid id, CancellationToken cancellationToken);
        Task UpdateAccount(Account account, CancellationToken cancellationToken);
    }
}
