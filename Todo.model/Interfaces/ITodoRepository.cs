using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface ITodoRepository
    {
        public TodoList? GetList(int TodoListId);
        public void AddTodoItem(TodoItem todoItem, int listId);
        public void AddList(string Title);
        public void DeleteTodoItem(TodoItem todoItem);
        public void DeleteList(TodoList list);
        public StatusList? GetStatusOptions();
        public void UpdateDb();
        public List<string> GetListNames();
        public List<TodoList> GetLists();

    }
}
