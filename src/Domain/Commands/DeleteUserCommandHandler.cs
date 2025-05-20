using Domain.RepositoryInterfaces;
using MediatR;

namespace Domain.Commands;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    public IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null) 
            return false;       

        return await _userRepository.RemoveAsync(user, cancellationToken);
    }
}
