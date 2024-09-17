namespace Application.DeleteUserComand
{
    public interface IDeleteUserComandHandler
    {
        Task HandleAsync(DeleteUserComand comand, CancellationToken cancellationToken);
    }
}
