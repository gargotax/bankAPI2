


using Domain.Entities;

namespace Application.TransactionComands
{
    public class CreateTransactionComand
    {
        public Guid Id { get;}
        public decimal Amount { get;}
        public DateTime CreatedDate { get;}
        public Transaction.Direction Direction { get; }
        public CreateTransactionComand(Guid id, decimal amount, DateTime createdDate, Transaction.Direction direction)
        {
            Id = id;
            Amount = amount;
            CreatedDate = createdDate;
            Direction = direction;
        }
    }
}
