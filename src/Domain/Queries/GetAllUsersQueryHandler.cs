using Domain.Entities;
using Domain.RepositoryInterfaces;
using MediatR;

namespace Domain.Queries;
public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
{
    public IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return _userRepository.GetAllAsync(cancellationToken);
    }
}
