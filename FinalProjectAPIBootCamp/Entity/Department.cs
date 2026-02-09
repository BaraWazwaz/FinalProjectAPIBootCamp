using System.ComponentModel.DataAnnotations;

namespace FinalProjectAPIBootCamp.Entity;

public class Department
{
	[Key]
	public Guid Id { get; set; } = Guid.NewGuid();
	[Required]
	public string Name { get; set; }
}
