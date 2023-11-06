using Microsoft.EntityFrameworkCore;
using Regwizard.Models;

namespace Regwizard.Db;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<User> User { get; set; }
    public DbSet<Province> Province { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>();
        modelBuilder.Entity<Province>();
    }
}