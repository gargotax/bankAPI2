namespace Application.UpdateUserComand
{
    public interface IUpdateUserComandHandler
    {
        Task HandleAsync(UpdateUserComand comandm , CancellationToken cancellationToken);   
    }
}
