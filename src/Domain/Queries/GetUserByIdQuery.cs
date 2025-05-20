using Domain.Entities;
using MediatR;

namespace Domain.Queries;
public class GetUserByIdQuery : IRequest<User>
{
    public Guid Id { get; set; }
}