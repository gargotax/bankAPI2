namespace Domain.Entities
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(Guid id, Guid userId) : base(id, userId)
        {
        }

        public override void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException();
            }

            Balance += amount;
        }
    }
}
