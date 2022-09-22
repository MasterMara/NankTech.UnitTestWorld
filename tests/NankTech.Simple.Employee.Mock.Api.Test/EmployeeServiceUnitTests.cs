using Moq;
using NankTech.Simple.Employee.Mock.Api.Controllers;
using NankTech.Simple.Employee.Mock.Api.Services;

namespace NankTech.Simple.Employee.Mock.Api.Test;

public class EmployeeServiceUnitTests
{
    
    private readonly Mock<IEmployeeService> _mockEmployeeService = new Mock<IEmployeeService>();
    private  EmployeeController _employeeController;
    

    [Fact]
    public async void GetEmployeeById_Should_Return_Single_Employee_When_Coming_Exist_Employee_Id()
    {
        //Arrange
        _mockEmployeeService.Setup(e => e.GetEmployeeById(1))
            .ReturnsAsync("MK");

        _employeeController = new EmployeeController(_mockEmployeeService.Object);

        //Act
        var actualResult = await _employeeController.GetEmployeeById(1);

        //Assert
        Assert.Equal("MK", actualResult);
    }

    [Fact]
    public async void GetEmployeeDetails_Should_Return_All_Employee_Detail_When_Coming_Exist_Employee_Id()
    {
        //Arrange
        var myMockEmployeeDto = new Model.Employee()
        {
            Id = 1,
            Name = "MK",
            Desgination = "ASD"
        };
        
        _mockEmployeeService.Setup(e => e.GetEmployeeDetailsById(1))
            .ReturnsAsync(myMockEmployeeDto);
        
        _employeeController = new EmployeeController(_mockEmployeeService.Object);

        //Act
        var actualResult = await _employeeController.GetEmployeeDetailsById(1);
        
        //Assert
        Assert.True(myMockEmployeeDto.Equals(actualResult));

    }
    
}