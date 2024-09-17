using Domain.Entities;
using Domain.Repos;

namespace Application.CreateUserComand
{
    public class CreateUserComandHandler : ICreateUserComandHandler
    {
        private readonly IUserRepository _userRepository;
        public CreateUserComandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<Guid> HandleAsync(CreateUserComand comand, CancellationToken cancellationToken)
        {
            User user = new User(Guid.NewGuid(), comand.Name);
            _userRepository.CreateUser(user, cancellationToken);
            return Task.FromResult(user.Id);
        }
    }
}
