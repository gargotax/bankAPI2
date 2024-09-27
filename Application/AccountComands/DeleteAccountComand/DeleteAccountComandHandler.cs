using Domain.Repos;


namespace Application.AccountComands.DeleteAccountComand
{
    public class DeleteAccountComandHandler : IDeleteAccountComandHandler
    {
        private readonly IAccountRepository _accountRepository;
        public DeleteAccountComandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Task HandleAsync(DeleteAccountComand comand, CancellationToken cancellationToken)
        {
           Guid idAccountToDelete = comand.AccountId;
           return _accountRepository.DeleteAccount(idAccountToDelete, cancellationToken);
        }
    }
}
