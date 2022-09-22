using Microsoft.EntityFrameworkCore;
using NankTech.Simple.Employee.Mock.Api.Model;

namespace NankTech.Simple.Employee.Mock.Api.Services;

public class EmployeeService : IEmployeeService
{
    #region Property
    private readonly AppDbContextx _appDbContext;
    #endregion

    #region Constructor
    public EmployeeService(AppDbContextx appDbContext)
    {
        _appDbContext = appDbContext;
    }
    #endregion

    public async Task<string> GetEmployeeById(int EmpID)
    {
        var name = await _appDbContext.Employees.Where(c=>c.Id == EmpID).Select(d=> d.Name).FirstOrDefaultAsync();
        return name;
    }

    public async Task<Model.Employee> GetEmployeeDetailsById(int EmpID)
    {
        var emp = await _appDbContext.Employees.FirstOrDefaultAsync(c => c.Id == EmpID);
        return emp;
    }
}