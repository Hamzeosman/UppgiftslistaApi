using UppgiftslistaApi.Models;

namespace UppgiftslistaApi.Services;

public interface ITodoService
{
    List<TodoItem> GetAll();
    TodoItem? GetById(int id);
    TodoItem Create(TodoItem item);
    bool Update(int id, TodoItem updated);
    bool Delete(int id);
    List<TodoItem> Search(string? q);
    bool SetFile(int id, string? fileName);
}