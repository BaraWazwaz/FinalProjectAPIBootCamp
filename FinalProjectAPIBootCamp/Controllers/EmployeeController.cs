using FinalProjectAPIBootCamp.Database;
using FinalProjectAPIBootCamp.DTOs;
using FinalProjectAPIBootCamp.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPIBootCamp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
	private readonly AppDbContext _context;
	public EmployeeController(AppDbContext context)
	{
		_context = context;
	}

	private EmployeeDTO restructure(Employee employee)
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
		var response = new List<EmployeeDTO>();
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
		
		var employee = new Employee()
		{
			Name = name,
			DepartmentId = departmentId,
			Department = department
		};
		_context.Employees.Add(employee);
		employee.Department.Employees.Add(employee);
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
		employee.Department = department;
		_context.SaveChanges();
		return Ok();
	}

	// delete
	[HttpDelete]
	public IActionResult deleteEmployee(Guid id) {
		var employee = _context.Employees.Find(id);
		if (employee == null)
			return NotFound();
		
		employee.Department.Employees.Remove(employee);
		_context.Employees.Remove(employee);
		_context.SaveChanges();
		return Ok();
	}
}
