using MediatR;

namespace Domain.Commands;
public class UpdateUserCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UpdateUserCommand(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}
