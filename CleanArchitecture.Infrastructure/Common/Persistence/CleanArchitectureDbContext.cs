using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Common.Persistence;

public class CleanArchitectureDbContext: DbContext, IUnitOfWork
{
    public DbSet<User> Users { get; set; }

    public CleanArchitectureDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}