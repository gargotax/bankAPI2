using Domain.Entities;
using Domain.Repos;
namespace Application.AccountComands.GetAccountComand
{
    public class GetAccountComandHandler : IGetAccountComandHandler
    {
        private readonly IAccountRepository _accountRepository;
        public GetAccountComandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<Account> HandleAsync(GetAccountComand comand, CancellationToken cancellationToken)
        {
            Account? account = await _accountRepository.GetAccountById(comand.AccountId, cancellationToken);
            if(account == null)
            {
                throw new KeyNotFoundException();
            }

            return account;
        }
    }
}
