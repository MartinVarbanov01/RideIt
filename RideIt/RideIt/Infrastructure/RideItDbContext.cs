using Microsoft.EntityFrameworkCore;
using RideIt.Features.Blogs;
using RideIt.Features.Marathons;
using RideIt.Features.Users;

namespace RideIt.Infrastructure;

public class RideItDbContext : DbContext
{
    public RideItDbContext(DbContextOptions<RideItDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Marathon> Marathons { get; set; }
    public DbSet<Blog> Blogs { get; set; }
}