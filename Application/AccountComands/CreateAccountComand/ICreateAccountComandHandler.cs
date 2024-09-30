
namespace Application.AccountComands.CreateAccountComand
{
    public interface ICreateAccountComandHandler
    {
        Task<Guid> HandleAsync(CreateAccountComand comand, CancellationToken cancellationToken);
    }
}
