using MediatR;

namespace Domain.Commands;
public class DeleteUserCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
