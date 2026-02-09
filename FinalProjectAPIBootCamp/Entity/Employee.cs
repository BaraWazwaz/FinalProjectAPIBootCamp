using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectAPIBootCamp.Entity;

public class Employee
{
	[Key]
	public Guid Id { get; set; } = Guid.NewGuid();
	[Required]
	public string Name { get; set; }
	[Required]
	public Guid DepartmentId { get; set; }
	[Required]
	[ForeignKey("DepartmentId")]
	public Department Department { get; set; }
}
