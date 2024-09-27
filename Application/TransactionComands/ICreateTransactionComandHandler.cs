
namespace Application.TransactionComands
{
    public interface ICreateTransactionComandHandler
    {
        Task<Guid> HandleAsync(CreateTransactionComand comand, CancellationToken cancellationToken);
    }
}
