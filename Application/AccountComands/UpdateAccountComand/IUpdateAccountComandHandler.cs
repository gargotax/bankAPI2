

namespace Application.AccountComands.UpdateAccountComand
{
    public interface IUpdateAccountComandHandler
    {
        Task HandleAsync(UpdateAccountComand comand, CancellationToken cancellationToken);
    }
}
