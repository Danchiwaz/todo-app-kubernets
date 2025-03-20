using BackendApi.Data;
using BackendApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Services;

public class TodoService : ITodoService
{
    private readonly AppDbContext _context;

    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TodoItem>> GetTodosAsync()
    {
        return await _context.TodoItems.ToListAsync();
    }

    public async Task<TodoItem> GetTodoByIdAsync(int id)
    {
        return await _context.TodoItems.FindAsync(id);
        
    }

    public async Task<TodoItem> CreateTodoAsync(TodoItem todo)
    {
        _context.TodoItems.Add(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<bool> UpdateToDoAsync(TodoItem todo)
    {
        var existingTodo = await _context.TodoItems.FindAsync(todo.Id);
        if (existingTodo == null) return false;
        existingTodo.Title = todo.Title;
        existingTodo.IsCompleted = todo.IsCompleted;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTodoAsync(int id)
    {
        var todo = await _context.TodoItems.FindAsync(id);
        if (todo == null) return false;
        _context.TodoItems.Remove(todo);
        await _context.SaveChangesAsync();
        return true;

    }
}