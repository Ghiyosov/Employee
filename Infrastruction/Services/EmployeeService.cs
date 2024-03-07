using Dapper;
using Domein.Models;
using Infrastruction.DataDapper;

namespace Infrastruction.Services;

public class EmployeeService
{
    readonly DapperContext _context;
    public EmployeeService()
    {
        _context = new DapperContext();
    }
    public List<Employees> GetEmployees()
    {
        return _context.Connection().Query<Employees>("select * from employees").ToList();
    }
    public void AddEmployee(Employees employees)
    {
        _context.Connection().Execute(@"insert into employees(firstname,lastname,departmentid,position,heredate)
                                       value(@firstname,@lastname,@departmentid,@position,@heredate)", employees);
    }
    public void UpdateEmployee(Employees employees)
    {
        _context.Connection().Execute(@"update employees as d 
                                        set firstname=@firstname,lastname=@lastname,departmentid=@departmentid,position=@position,heredate=@heredate
                                        where d.id=@id", employees);
    }
    public void DeleteEmployee(int id)
    {
        _context.Connection().Execute("delet from employees as d where d.id=@id", new { Id = id });
    }
    public DepartamentEmployees GetDepartamentEmployees(int id)
    {
        var sql = @"select * from departments as d where d.id=@id;
                  select * from employees as em where em.departmentid=@id";
        using (var multi = _context.Connection().QueryMultiple(sql, new { Id = id }))
        {
            var ms = new DepartamentEmployees();
            ms.Department = multi.ReadFirst<Departments>();
            ms.Employees = multi.Read<Employees>().ToList();
            return ms;
        }

    }
    public List<DepartmentAvgSalary> GetDepartmentAvgSalary()
    {
        var depid = _context.Connection().Query<int>("select d.id from departments").ToList();
        var sql = @"select * from departments as d where d.id=@item; 
                    select avg(s.amount) as AvgSalary
                    from employees as em
                    where em.departmentid=@item
                    join department as d on em.departmentid=d.id
                    join salaries as s on em.salaryid=s.id";
        List<DepartmentAvgSalary> avg = new List<DepartmentAvgSalary>();
        foreach (var item in avg)
        {
            var sal = new DepartmentAvgSalary();
            using (var multiple = _context.Connection().QueryMultiple(sql, new { Item = item }))
            {
                sal.Department = multiple.ReadFirst<Departments>();
                sal.AvgSalary = multiple.Read<decimal>();
                avg.Add(sal);
            }
        }
        return avg;
    }

}
