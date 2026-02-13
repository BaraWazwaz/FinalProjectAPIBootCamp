using FinalProjectAPIBootCamp.Database;
using FinalProjectAPIBootCamp.DTOs;
using FinalProjectAPIBootCamp.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPIBootCamp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
	private readonly AppDbContext _context;
	public DepartmentController(AppDbContext context)
	{
		_context = context;
	}

	private DepartmentDTO restructure(Department department)
	{
		return new()
		{
			Id = department.Id,
			Name = department.Name
		};
	}

	// get all
	[HttpGet]
	public IActionResult getDepartments()
	{
		var depratments = _context.Departments.ToList();
		var response = new List<DepartmentDTO>();
		foreach (var department in depratments)
			response.Add(restructure(department));
		return Ok(response);
	}

	// get single
	[HttpGet("{id}")]
	public IActionResult getDepartment([FromRoute] Guid id)
	{
		var department = _context.Departments.Find(id);
		if (department == null)
			return NotFound();
		else
			return Ok(restructure(department));
	}

	// add
	[HttpPost]
	public IActionResult addDepartment(string name)
	{
		if (name == null)
			return BadRequest("Name cannot be null");
	
		var department = new Department
		{
			Name = name
		};
		_context.Departments.Add(department);
		_context.SaveChanges();
		return Ok();
	}

	// update
	[HttpPut]
	public IActionResult updateDepartment(Guid id, string name)
	{
		if (name == null)
			return BadRequest("Name cannot be null");
		
		var department = _context.Departments.Find(id);
		if (department == null)
			return NotFound();
		
		department.Name = name;
		_context.SaveChanges();
		return Ok();
	}

	// delete
	[HttpDelete]
	public IActionResult deleteDepartment(Guid id)
	{
		var department = _context.Departments.Find(id);
		if (department == null)
			return NotFound();
		
		foreach (var employee in department.Employees)
		{
			if (employee != null)
				_context.Employees.Remove(employee);
		}
		_context.Departments.Remove(department);
		_context.SaveChanges();
		return Ok();
	}
}
