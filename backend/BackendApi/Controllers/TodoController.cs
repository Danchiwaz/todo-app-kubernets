using BackendApi.Models;
using BackendApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers;

[Route("api/todos")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
    {
        return Ok(await _todoService.GetTodosAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetToDoById(int id)
    {
        var todo = await _todoService.GetTodoByIdAsync(id);
        if (todo == null) return NotFound();
        return Ok(todo);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTodo(TodoItem todo)
    {
        var createTodod = await _todoService.CreateTodoAsync(todo);
        return CreatedAtAction(nameof(GetToDoById), new { id = todo.Id }, todo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(int id, TodoItem todo)
    {
        if (id ! == todo.Id) return BadRequest();
        var updated = await _todoService.UpdateToDoAsync(todo);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        var deleted = await _todoService.DeleteTodoAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}