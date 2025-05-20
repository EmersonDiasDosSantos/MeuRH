using Domain.RepositoryInterfaces;
using MediatR;

namespace Domain.Commands;
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    public IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null) 
            return false;

        user.UpdateUser(request.Name, request.Email);

        return await _userRepository.UpdateAsync(user, cancellationToken);
    }
}
