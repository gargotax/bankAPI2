namespace Application.UserComands.UpdateUserComand
{
    public interface IUpdateUserComandHandler
    {
        Task HandleAsync(UpdateUserComand comandm, CancellationToken cancellationToken);
    }
}
