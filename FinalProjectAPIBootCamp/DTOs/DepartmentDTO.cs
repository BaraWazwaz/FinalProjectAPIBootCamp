using System.ComponentModel.DataAnnotations;

namespace FinalProjectAPIBootCamp.DTOs;

public class DepartmentDTO
{
	[Key]
	public Guid Id { get; set; }
	[Required]
	public string Name { get; set; }
}
