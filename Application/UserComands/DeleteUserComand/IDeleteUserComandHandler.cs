namespace Application.UserComands.DeleteUserComand
{
    public interface IDeleteUserComandHandler
    {
        Task HandleAsync(DeleteUserComand comand, CancellationToken cancellationToken);
    }
}
