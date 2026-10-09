using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface ITodoService
    {
        public void Add(int listId, TodoItem todoItem);
        public void UpdateDb();
        public void Delete(int listId, TodoItem todoItem);
        public void AddList(string Title);
        public void DeleteList(string Title);

        public TodoList GetTodoList(int listId);
        public StatusList GetStatusOptions();
        public List<string> GetListNames();
    }
}
