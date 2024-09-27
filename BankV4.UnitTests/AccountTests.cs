using Domain.Entities;
using FluentAssertions;

namespace BankV4.UnitTests
{
    public class AccountTests
    {
        [Fact]
        public void WithDraw_Amount_Less_Than_Zero_Should_Throw_Exception()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            Guid usertId = Guid.NewGuid();
            Account account = new CurrentAccount(accountId, usertId);

            //Act
            Action act = () => account.Withdraw(-1);
            
            //Assert
            act.Should().Throw<Exception>();
            
        }

        [Fact]
        public void Balance_After_Operation_Less_Than_OverdDraft_Should_Throw_Exception()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            Guid usertId = Guid.NewGuid();
            Account account = new CurrentAccount(accountId, usertId);

            //Act
            Action act = () => account.Withdraw(1600);

            //Assert
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void Withdraw_With_Balance_Less_Than_OverDraft_Should_Throw_Exception()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            Guid usertId = Guid.NewGuid();
            Account account = new CurrentAccount(accountId, usertId);

            //Act
            Action act = () => account.Withdraw(1501);

            //Assert
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void Deposit_Amount_Less_Than_One_Should_Throw_Exception()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            Guid usertId = Guid.NewGuid(); 
            Account account = new CurrentAccount(accountId, usertId);

            //Act
            Action act = () => account.Deposit(0);

            //Assert
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void Current_Account_Balance_Should_Be_Updated_After_Deposit()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            Guid usertId = Guid.NewGuid();
            Account account = new SavingAccount(accountId, usertId, 1000, -500);

            //Act
            account.Deposit(20);

            //Assert
            account.Balance.Should().Be(1020);
        }

        [Fact]
        public void Current_Account_Balance_Should_Be_Updated_After_Withdraw()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            Guid usertId = Guid.NewGuid();
            Account account = new SavingAccount(accountId, usertId, 1000, -500);

            //Act
            account.Withdraw(1);

            //Assert
            account.Balance.Should().Be(999);
        }

        [Fact]
        public void Saving_Account_Balance_Should_Be_Updated_After_Deposit()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            Guid usertId = Guid.NewGuid();
            Account account = new SavingAccount(accountId, usertId, 1000, -500);

            //Act
            account.Deposit(10);

            //Assert
            account.Balance.Should().Be(1010);
        }

        [Fact]
        public void New_Current_Account_Should_Have_OneThousand_Balance_And_Less_Than_FiveHundred_Overdraft()
        {
            //Arrange
            Guid accountId = Guid.NewGuid();
            Guid usertId = Guid.NewGuid();

            //Act
            Account account = new CurrentAccount(accountId, usertId);

            //Assert
            account.Balance.Should().Be(1000);
            account.Overdraft.Should().Be(-500);
        }
    }    
}