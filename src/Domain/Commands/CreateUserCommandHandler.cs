using Domain.Entities;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Domain.Commands;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    public IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Email);

        await _userRepository.AddAsync(user, cancellationToken);

        return user.Id;
    }
}
