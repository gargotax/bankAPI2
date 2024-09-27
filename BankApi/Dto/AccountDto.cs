using Domain.Entities;

namespace BankApi.Dto
{
    public record AccountDto(Guid? UserId,Account.AccountType AccountType, decimal Balance);
    
    
}
