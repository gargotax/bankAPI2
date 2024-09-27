using Domain.Entities;
using Domain.Repos;

namespace Infrastructure
{
    public class AccountRepository : IAccountRepository
    {
        private static Dictionary<Guid, Account> _accounts = new Dictionary<Guid, Account>();
        public Task<Guid> CreateAccount(Account account, CancellationToken cancellationToken)
        {
           _accounts.TryAdd(account.Id, account);
            return Task.FromResult(account.Id);
        }

        public Task DeleteAccount(Guid id, CancellationToken cancellationToken)
        {
            _accounts.Remove(id);
            return Task.CompletedTask;
        }

        public Task<Account?> GetAccountById(Guid id, CancellationToken cancellationToken)
        {
            _accounts.TryGetValue(id, out Account? account);
            return Task.FromResult(account);
        }

        public Task UpdateAccount(Account account, CancellationToken cancellationToken)
        {
            _accounts[account.Id] = account;
            return Task.CompletedTask;
        }
    }
}
