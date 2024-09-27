namespace Domain.Entities
{
    public class Transaction
    {
        public Guid TransactionId { get;}
        public Guid AccountId { get;}
        public decimal Amount { get;}
        public DateTime TransactionTime { get;}
        public enum Direction
        {
            Debit = 0,
            Credit = 1,
        }
        public Direction TransactionDirection { get; }
        public Transaction(Guid transactionId, Guid accountId, decimal amount, DateTime transactionTime, Direction direction)
        {
            TransactionId = transactionId;
            AccountId = accountId;
            Amount = amount;
            TransactionTime = transactionTime;
            TransactionDirection = direction;

        }
    }
}
