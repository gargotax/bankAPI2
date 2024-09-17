using Domain.Entities;
namespace Domain.Repos
{
    public interface IUserRepository
    {
        Task<Guid> CreateUser(User user, CancellationToken cancellationToken);
        Task<User?> GetUserById(Guid id, CancellationToken cancellationToken);
        Task DeleteUser(Guid id, CancellationToken cancellationToken);
        Task UpdateUser(User user, CancellationToken cancellationToken);
    }
}
