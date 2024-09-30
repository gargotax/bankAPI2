namespace Domain.Entities
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(Guid id, Guid userId) : base(id, userId)
        {
        }

        public override void Credit(decimal amount)
        {
            if (amount < 1)
            {
                throw new ArgumentException();
            }

            Balance += amount;
        }
    }
}
