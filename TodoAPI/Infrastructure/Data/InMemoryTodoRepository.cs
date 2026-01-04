using TodoAPI.Core.Models;
using TodoAPI.Core.Interfaces;

namespace TodoAPI.Infrastructure.Data
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        private readonly List<TodoItem> _todos = new();
        private int _nextId = 1;

        public IEnumerable<TodoItem> GetAll() => _todos;

        public TodoItem Add(string title)
        {
            var item = new TodoItem(_nextId++, title, false);
            _todos.Add(item);
            return item;
        }

        public bool Delete(int id) => _todos.RemoveAll(t => t.Id == id) > 0;
    }
}
