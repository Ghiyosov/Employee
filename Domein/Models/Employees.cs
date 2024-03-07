namespace Domein.Models;

public class Employees
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int DepartmentId { get; set; }
    public string Position { get; set; }
    public DateTime HereDate { get; set; }
}
