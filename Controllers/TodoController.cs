using Microsoft.AspNetCore.Mvc;
using UppgiftslistaApi.Models;
using UppgiftslistaApi.Services;

namespace UppgiftslistaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _service;

    public TodoController(ITodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("search")]
    public IActionResult Search([FromQuery] string? q)
    {
        return Ok(_service.Search(q));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var todo = _service.GetById(id);
        if (todo is null)
            return NotFound();
        return Ok(todo);
    }

    [HttpPost]
    public IActionResult Create(TodoItem newTodo)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = _service.Create(newTodo);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TodoItem updated)
    {
        var ok = _service.Update(id, updated);
        if (!ok)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var ok = _service.Delete(id);
        if (!ok)
            return NotFound();
        return NoContent();
    }

    [HttpPost("{id}/upload")]
    public async Task<IActionResult> UploadFile(int id, IFormFile file)
    {
        var todo = _service.GetById(id);
        if (todo is null)
            return NotFound();

        if (file is null || file.Length == 0)
            return BadRequest("Ingen fil vald.");

        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        Directory.CreateDirectory(uploadsFolder);

        var safeFileName = $"{id}_{Path.GetFileName(file.FileName)}";
        var filePath = Path.Combine(uploadsFolder, safeFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        _service.SetFile(id, safeFileName);

        return Ok(new { fileName = safeFileName });
    }
}