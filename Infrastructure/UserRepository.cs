using Domain.Entities;
using Domain.Repos;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private static Dictionary<Guid,User> _users = new Dictionary<Guid,User>();
        public Task<Guid> CreateUser(User user, CancellationToken cancellationToken)
        {
            _users.TryAdd(user.Id, user);
            return Task.FromResult(user.Id);
        }

        public Task DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            _users.Remove(id);
            return Task.CompletedTask;
        }

        public Task<User?> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            _users.TryGetValue(id, out var user);
            return Task.FromResult(user);
        }

        public Task UpdateUser(User user, CancellationToken cancellationToken)
        {
            _users[user.Id] = user;
            return Task.CompletedTask;
        }
    }
}
