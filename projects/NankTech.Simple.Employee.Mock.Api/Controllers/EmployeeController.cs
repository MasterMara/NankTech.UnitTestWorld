using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NankTech.Simple.Employee.Mock.Api.Services;

namespace NankTech.Simple.Employee.Mock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Property
        private readonly IEmployeeService _employeeService;
        #endregion

        #region Constructor
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        [HttpGet(nameof(GetEmployeeById))]
        public async Task<string> GetEmployeeById(int EmpID)
        {
            var result = await _employeeService.GetEmployeeById(EmpID);
            return result;
        }
        [HttpGet(nameof(GetEmployeeDetailsById))]
        public async Task<Model.Employee> GetEmployeeDetailsById(int EmpID)
        {
            var result = await _employeeService.GetEmployeeDetailsById(EmpID);
            return result;
        }

    }
}
