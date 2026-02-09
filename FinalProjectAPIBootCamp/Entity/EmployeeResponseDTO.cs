namespace FinalProjectAPIBootCamp.Entity;

public class EmployeeResponseDTO
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Name { get; set; }
	public Guid DepartmentId { get; set; }
	public string DepartmentName { get; set; }
}
