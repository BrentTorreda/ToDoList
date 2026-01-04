using TodoAPI.Core.Models;

namespace TodoAPI.Core.Interfaces
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem Add(string title);
        bool Delete(int id);
    }
}
