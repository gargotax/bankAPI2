namespace Domain.Entities
{
    public abstract class Account
    {
        public Guid Id { get;}
        public Guid UserId { get;}
        public decimal Overdraft { get; private set; }
        public decimal Balance { get; protected set; }
        public Account(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
            Balance = 1000;
            Overdraft = -500;
        }
        public enum AccountType
        {
            CurrentAccount = 0,
            SavingAccount = 1,
        }
        public abstract void Credit(decimal amount);
        public void Debit(decimal amount)
        {
            CheckAmountLessThanZero(amount);

            decimal balanceAfterWithDraw = Balance - amount;

            if (balanceAfterWithDraw < Overdraft)
            {
                throw new Exception();
            }
            if (Balance <= Overdraft)
            {
                throw new Exception();
            }

            Balance -= amount;
        }

        private static void CheckAmountLessThanZero(decimal amount)
        {
            if (amount < 0)
            {
                throw new Exception();
            }
        }
    }
}
