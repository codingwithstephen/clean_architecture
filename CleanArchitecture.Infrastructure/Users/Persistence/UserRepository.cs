using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Users.Persistence;

public class UserRepository: IUserRepository
{
    private static CleanArchitectureDbContext _dbContext;

    public UserRepository(CleanArchitectureDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddUserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);

    }
    
    public async Task<User?> GetByIdAsync(long userId, CancellationToken cancellationToken)
    {
        var user = await _dbContext?.Users.FirstOrDefaultAsync(u => u.Id == userId);
        return user;
    }
}