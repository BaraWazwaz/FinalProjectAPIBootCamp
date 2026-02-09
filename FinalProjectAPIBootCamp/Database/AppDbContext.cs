using FinalProjectAPIBootCamp.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectAPIBootCamp.Database;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
	public DbSet<Department> Departments { get; set; }
	public DbSet<Employee> Employees { get; set; }
}
