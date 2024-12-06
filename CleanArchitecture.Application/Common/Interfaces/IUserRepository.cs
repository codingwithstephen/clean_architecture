using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<User?> GetByIdAsync(long userId, CancellationToken cancellationToken);
}