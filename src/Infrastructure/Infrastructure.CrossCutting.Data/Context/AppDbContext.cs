using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.CrossCutting.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
