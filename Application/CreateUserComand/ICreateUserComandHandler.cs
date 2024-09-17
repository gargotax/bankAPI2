

namespace Application.CreateUserComand
{
    public interface ICreateUserComandHandler
    {
        Task<Guid> HandleAsync(CreateUserComand comand, CancellationToken cancellationToken);
    }
}
