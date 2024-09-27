
using Domain.Entities;

namespace BankApi.Models
{
    public record CreateTransactionRequest(decimal Amount, Transaction.Direction Direction);
    
    
}
