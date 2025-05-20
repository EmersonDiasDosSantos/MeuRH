using Domain.Entities;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Domain.Queries;
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    public IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}
