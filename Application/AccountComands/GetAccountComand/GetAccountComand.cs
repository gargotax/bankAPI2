

namespace Application.AccountComands.GetAccountComand
{
    public class GetAccountComand
    {
        public Guid AccountId { get;}
        public GetAccountComand(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
