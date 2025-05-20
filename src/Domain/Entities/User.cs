using Domain.Commands;
using Domain.Entities.Base;

namespace Domain.Entities;

public class User : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedAt { get; set; }     
    public DateTime? UpdatedAt { get; set; }         
    public bool IsActive { get; set; } = true;       

    protected User() { }

    public User(string name, string email)
    {
        Name = name;
        Email = email;
        CreatedAt = DateTime.UtcNow;

        Validar();
    }

    public void UpdateUser(string name, string email)
    {
        Name = name;
        Email = email;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Validar()
    {
        //
    }
}
