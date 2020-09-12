using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArithematicAPIService.v1.Data;
using ArithematicAPIService.v1.Models;
using ArithematicLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ArithematicAPIService.v1.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private const string ControllerPath = @"/api/v1/employees";

        private EmployeeDataContext _employeeDataContext;
        public EmployeeController(EmployeeDataContext employeeDataContext)
        {
            _employeeDataContext = employeeDataContext;
        }

        [HttpPost]
        [Route(ControllerPath + "/add")]
        public long Add(Employee employee)
        {
            _employeeDataContext.Employees.Add(employee);
            _employeeDataContext.SaveChanges();

            return employee.EmployeeId;
        }

        [HttpGet]
        [Route(ControllerPath + "/{employeeid}")]
        public Employee GetEmployee(long employeeid)
        {
            return GetEmployeeInternal(employeeid);
        }

        private Employee GetEmployeeInternal(long employeeid)
        {
            var result = _employeeDataContext.Employees.FirstOrDefault(emp => emp.EmployeeId == employeeid);

            return result;
        }

        [HttpPut]
        [Route(ControllerPath + "/update")]
        public void UpdateEmployee(Employee employee)
        {
            _employeeDataContext.Employees.Update(employee);
            _employeeDataContext.SaveChanges();
        }

        [HttpDelete]
        [Route(ControllerPath + "/{employeeid}/delete")]
        public void DeleteEmployee(long employeeid)
        {
            _employeeDataContext.Employees.Remove(GetEmployeeInternal(employeeid));
            _employeeDataContext.SaveChanges();
        }
    }
}
