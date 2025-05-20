using Domain.Entities;

namespace Domain.RepositoryInterfaces;
public interface IUserRepository
{
    Task<bool> AddAsync(User entity, CancellationToken cancellationToken);
    Task<bool> RemoveAsync(User entity, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(User entity, CancellationToken cancellationToken);

    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<User?>> GetAllAsync(CancellationToken cancellationToken);

    Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken);
}
