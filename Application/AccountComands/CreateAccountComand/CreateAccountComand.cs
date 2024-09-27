using Domain.Entities;

namespace Application.AccountComands.CreateAccountComand
{
    public class CreateAccountComand
    {
        public User User { get; }
        public CreateAccountComand(User user)
        {
            User = user;
        }
    }
}
