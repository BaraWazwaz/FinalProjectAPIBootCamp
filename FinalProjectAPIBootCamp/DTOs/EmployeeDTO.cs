namespace FinalProjectAPIBootCamp.DTOs;

public class EmployeeDTO
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Name { get; set; }
	public Guid DepartmentId { get; set; }
	public string DepartmentName { get; set; }
}
