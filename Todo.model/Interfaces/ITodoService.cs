using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface ITodoService
    {
        public void Add(int listId, TodoItem todoItem);
        public void UpdateTodoItem(TodoItem todoItem);
        public void Delete(int listId, TodoItem todoItem);
        public TodoList GetTodoList(int listId);
        public StatusList GetStatusOptions();
        public void UpdateStatusOptions(StatusList options);

    }
}
