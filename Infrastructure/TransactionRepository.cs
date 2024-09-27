using Domain.Entities;
using Domain.Repos;

namespace Infrastructure
{
    public class TransactionRepository:ITransactionRepository
    {
        private static Dictionary<Guid, Transaction> _transactions = new();
        public Task<Guid> CreateTransaction(Transaction transaction, CancellationToken cancellationToken)
        {
            _transactions.TryAdd(transaction.TransactionId, transaction);
            return Task.FromResult(transaction.TransactionId);
        }
    }
}
