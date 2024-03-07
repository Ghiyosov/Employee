namespace Domein.Models;

public class Salaries
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateSalary { get; set; }
}
