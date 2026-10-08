using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface ITodoRepository
    {
        public TodoList? GetList(int TodoListId);
        public void AddTodoItem(TodoItem todoItem);
        public void DeleteTodoItem(TodoItem todoItem);
        public StatusList? GetStatusOptions();
        void UpdateTodoItem(TodoItem todoItem);
        public void UpdateStatusOptions(StatusList statusOptions);

    }
}
