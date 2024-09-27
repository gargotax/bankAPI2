namespace Domain.Entities
{
    public class SavingAccount : Account
    {
        public SavingAccount(Guid id, Guid userId, decimal balance, decimal overdraft) : base(id, userId)
        {
        }

        public override void Deposit(decimal amount)
        {
            Balance += amount;
        }
    }
}
