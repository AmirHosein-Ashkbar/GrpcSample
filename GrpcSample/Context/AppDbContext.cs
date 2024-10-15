using GrpcSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace GrpcSample.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Person> People{ get; set; }
}
