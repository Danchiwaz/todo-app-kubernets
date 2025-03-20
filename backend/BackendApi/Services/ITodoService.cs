using BackendApi.Models;

namespace BackendApi.Services;

public interface ITodoService
{
    Task<IEnumerable<TodoItem>> GetTodosAsync();
    Task<TodoItem> GetTodoByIdAsync(int id);
    Task<TodoItem> CreateTodoAsync(TodoItem todo);
    Task<bool> UpdateToDoAsync(TodoItem todo);
    Task<bool> DeleteTodoAsync(int id);

}