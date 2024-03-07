using Dapper;
using Domein.Models;
using Infrastruction.DataDapper;

namespace Infrastruction.Services;

public class DepartmentService
{
    readonly DapperContext _context;
    public DepartmentService()
    {
        _context = new DapperContext();
    }
    public List<Departments> GetDepartments()
    {
        return _context.Connection().Query<Departments>("select * from departments").ToList();
    }
    public void AddDepartment(Departments departments)
    {
        _context.Connection().Execute("insert into departments(name)value(@name)", departments);
    }
    public void UpdateDepartment(Departments departments)
    {
        _context.Connection().Execute("update departments as d set name=@name where d.id=@id", departments);
    }
    public void DeleteDepartment(int id)
    {
        _context.Connection().Execute("delet from departments as d where d.id=@id", new { Id = id });
    }
}
