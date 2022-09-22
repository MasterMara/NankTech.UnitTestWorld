using Microsoft.EntityFrameworkCore;

namespace NankTech.Simple.Employee.Mock.Api.Model;

public partial class AppDbContextx : DbContext
{
    public AppDbContextx(DbContextOptions<AppDbContextx> options) : base(options)
    {
    }
    public DbSet<Employee> Employees { get; set; }
}