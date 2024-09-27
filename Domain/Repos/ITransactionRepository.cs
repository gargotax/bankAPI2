using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domain.Repos
{
    public interface ITransactionRepository
    {
        Task<Guid> CreateTransaction(Entities.Transaction transaction, CancellationToken cancellationToken);
    }
}
