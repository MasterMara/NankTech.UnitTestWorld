namespace NankTech.Simple.Employee.Mock.Api.Services;

public interface IEmployeeService
{
    Task<string> GetEmployeebyId(int EmpID);
    Task<Model.Employee> GetEmployeeDetails(int EmpID);
}