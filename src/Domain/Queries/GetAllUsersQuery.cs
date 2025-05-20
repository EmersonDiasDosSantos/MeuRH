using Domain.Entities;
using MediatR;

namespace Domain.Queries;
public class GetAllUsersQuery : IRequest<IEnumerable<User>> {}