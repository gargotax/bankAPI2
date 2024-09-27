using Domain.Entities;
using Domain.Repos;
using static Domain.Entities.Transaction;

namespace Application.TransactionComands
{
    public class CreateTransactionComandHandler : ICreateTransactionComandHandler
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        public CreateTransactionComandHandler(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;

        }
        public async Task<Guid> HandleAsync(CreateTransactionComand comand, CancellationToken cancellationToken)
        {
            var accountToGet = await _accountRepository.GetAccountById(comand.Id, cancellationToken);
            if (accountToGet == null)
            {
                throw new KeyNotFoundException();
            }
            
            Transaction transaction = new(Guid.NewGuid(), accountToGet.Id, comand.Amount, comand.CreatedDate, comand.Direction);

            if (transaction.TransactionDirection == Direction.Debit)
            {
                accountToGet.Withdraw(comand.Amount); 
            }
            else if (transaction.TransactionDirection == Direction.Credit)
            {
                accountToGet.Deposit(comand.Amount);  
            }

            await _transactionRepository.CreateTransaction(transaction, cancellationToken);
            return transaction.TransactionId;
        }
    }
}
