using Dapper;
using Domein.Models;
using Infrastruction.DataDapper;

namespace Infrastruction.Services;

public class SalaryService
{
    readonly DapperContext _context;
    public SalaryService()
    {
        _context = new DapperContext();
    }
    public List<Salaries> GetSalaries()
    {
        return _context.Connection().Query<Salaries>("select * from salaries").ToList();
    }
    public void AddSalary(Salaries salaries)
    {
        _context.Connection().Execute("insert into salaries(employeeid,amount,datesalary)value(@employeeid,@amount,@datesalary)", salaries);
    }
    public void UpdateDepartmentSalary(Salaries salaries)
    {
        _context.Connection().Execute("update salaries as d set employeeid=@employeeid,amount=@amount,datesalary=@datesalary where d.id=@id", salaries);
    }
    public void DeleteSalary(int id)
    {
        _context.Connection().Execute("delet from salaries as d where d.id=@id", new { Id = id });
    }
}
