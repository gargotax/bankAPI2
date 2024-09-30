using Domain.Entities;
using Domain.Repos;

namespace Application.AccountComands.CreateAccountComand
{
    public class CreateAccountComandHandler : ICreateAccountComandHandler
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        public CreateAccountComandHandler(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;

        }
        public async Task<Guid> HandleAsync(CreateAccountComand comand, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserById(comand.UserId, cancellationToken);
            if(user == null)
            {
                throw new KeyNotFoundException();
            }
            Account account = new CurrentAccount(Guid.NewGuid(), user.Id);
            await _accountRepository.CreateAccount(account, cancellationToken);
            return account.Id;
        }
    }
}
