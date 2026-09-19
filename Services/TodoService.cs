using UppgiftslistaApi.Models;

namespace UppgiftslistaApi.Services;

public class TodoService : ITodoService
{
    private static List<TodoItem> _todos = new()
    {
        new TodoItem { Id = 1, Title = "Handla mat", Done = false },
        new TodoItem { Id = 2, Title = "Städa", Done = true },
    };

    public List<TodoItem> GetAll() => _todos;

    public TodoItem? GetById(int id) => _todos.FirstOrDefault(t => t.Id == id);

    public TodoItem Create(TodoItem item)
    {
        item.Id = _todos.Count == 0 ? 1 : _todos.Max(t => t.Id) + 1;
        _todos.Add(item);
        return item;
    }

    public bool Update(int id, TodoItem updated)
    {
        var todo = GetById(id);
        if (todo is null) return false;
        todo.Title = updated.Title;
        todo.Done = updated.Done;
        return true;
    }

    public bool Delete(int id)
    {
        var todo = GetById(id);
        if (todo is null) return false;
        _todos.Remove(todo);
        return true;
    }

    public List<TodoItem> Search(string? q) =>
        string.IsNullOrEmpty(q) ? _todos : _todos.Where(t => t.Title.Contains(q)).ToList();

    public bool SetFile(int id, string? fileName)
    {
        var todo = GetById(id);
        if (todo is null) return false;
        todo.FileName = fileName;
        return true;
    }
}