using Domain.Entities;
using Domain.Repos;

namespace Application.UpdateUserComand
{
    public class UpdateUserComandHandler : IUpdateUserComandHandler
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserComandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task HandleAsync(UpdateUserComand comand, CancellationToken cancellationToken)
        {
           User? userToUpdate = await _userRepository.GetUserById(comand.Id, cancellationToken);

            if(userToUpdate == null)
            {
                throw new KeyNotFoundException();
            }

            userToUpdate.UpdateName(comand.Name);
            await _userRepository.UpdateUser(userToUpdate, cancellationToken);
        }

    }
}
