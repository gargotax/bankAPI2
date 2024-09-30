namespace Domain.Entities
{
    public class SavingAccount : Account
    {
        public SavingAccount(Guid id, Guid userId) : base(id, userId)
        {
        }

        public override void Credit(decimal amount)
        {
            Balance += amount;
        }
    }
}
