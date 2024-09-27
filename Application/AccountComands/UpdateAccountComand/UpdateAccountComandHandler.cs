

using Domain.Entities;
using Domain.Repos;

namespace Application.AccountComands.UpdateAccountComand
{
    public class UpdateAccountComandHandler:IUpdateAccountComandHandler
    {
        private readonly IAccountRepository _accountRepository;
        public UpdateAccountComandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task HandleAsync(UpdateAccountComand comand, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountById(comand.Id, cancellationToken);
            if (account == null)
            {
                throw new KeyNotFoundException();
            }           
           await _accountRepository.UpdateAccount(account, cancellationToken);
        }
    }
}
