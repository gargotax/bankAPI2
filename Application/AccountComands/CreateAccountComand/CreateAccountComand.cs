
namespace Application.AccountComands.CreateAccountComand
{
    public class CreateAccountComand
    {
        public Guid UserId { get; }
        public CreateAccountComand(Guid userId)
        {
            UserId = userId;
        }
    }
}
