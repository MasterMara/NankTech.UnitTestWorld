namespace NankTech.Simple.Employee.Mock.Api.Services;

public interface IEmployeeService
{
    Task<string> GetEmployeeById(int EmpID);
    Task<Model.Employee> GetEmployeeDetailsById(int EmpID);
}