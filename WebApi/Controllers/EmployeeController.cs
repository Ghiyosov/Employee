using System.ComponentModel;
using Domein.Models;
using Infrastruction.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class EmployeeController
{
    readonly EmployeeService _employeeService;
    public EmployeeController()
    {
        _employeeService = new EmployeeService();
    }
    [HttpGet("get-employe")]
    public List<Employees> GetEmployees()
    {
        return _employeeService.GetEmployees();
    }
    [HttpPost("add-employee")]
    public void AddEmployee(Employees employees)
    {
        _employeeService.AddEmployee(employees);
    }
    [HttpPut("update-employee")]
    public void UpdateEmployee(Employees employees)
    {
        _employeeService.UpdateEmployee(employees);
    }
    [HttpDelete("delet-by-id")]
    public void DeleteEmployee(int id)
    {
        _employeeService.DeleteEmployee(id);
    }
    [HttpGet("get-department-employees")]
    public DepartamentEmployees GetDepartamentEmployees(int id)
    {
        return _employeeService.GetDepartamentEmployees(id);
    }
    [HttpGet("get-department-avg-salary")]
    public List<DepartmentAvgSalary> GetDepartmentAvgSalaries()
    {
        return _employeeService.GetDepartmentAvgSalary();
    }
}
