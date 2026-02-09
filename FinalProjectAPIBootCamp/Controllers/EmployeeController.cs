using FinalProjectAPIBootCamp.Database;
using FinalProjectAPIBootCamp.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPIBootCamp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
	private readonly AppDbContext _context;
	EmployeeController(AppDbContext context)
	{
		_context = context;
	}

	private EmployeeResponseDTO restructure(Employee employee)
	{
		var department = _context.Departments.Find(employee.DepartmentId);
		return new()
		{
			Id = employee.Id,
			Name = employee.Name,
			DepartmentId = department.Id,
			DepartmentName = department.Name
		};
	}

	// get all
	[HttpGet]
	public IActionResult getEmployees()
	{
		var employees = _context.Employees.ToList();
		var response = new List<EmployeeResponseDTO>();
		foreach (var employee in employees)
			response.Add(restructure(employee));
		return Ok(response);
	}

	// get single
	[HttpGet("{id}")]
	public IActionResult getEmployee([FromRoute] Guid id)
	{
		var employee = _context.Employees.Find(id);
		if (employee == null)
			return NotFound();
		else
			return Ok(restructure(employee));
	}

	// add
	[HttpPost]
	public IActionResult addEmployee(string name, Guid departmentId)
	{
		if (name == null)
			return BadRequest("Name cannot be null");
		var department = _context.Departments.Find(departmentId);
		if (department == null)
			return BadRequest("Department with such Id does not exist");
		_context.Employees.Add(new()
		{
			Name = name,
			DepartmentId = departmentId
		});
		_context.SaveChanges();
		return Ok();
	}

	// update
	[HttpPut]
	public IActionResult updateEmployee(Guid id, string name, Guid departmentId)
	{
		if (name == null)
			return BadRequest("Name cannot be null");
		var employee = _context.Employees.Find(id);
		if (employee == null)
			return NotFound();
		var department = _context.Departments.Find(departmentId);
		if (department == null)
			return BadRequest("Department with such id does not exist");
		employee.Name = name;
		employee.DepartmentId = departmentId;
		_context.SaveChanges();
		return Ok();
	}

	// delete
	[HttpDelete]
	public IActionResult deleteEmployee(Guid id) {
		var employee = _context.Employees.Find(id);
		if (employee == null)
			return NotFound();
		_context.Employees.Remove(employee);
		_context.SaveChanges();
		return Ok();
	}
}
