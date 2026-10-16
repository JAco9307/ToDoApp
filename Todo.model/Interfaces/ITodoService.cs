using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface ITodoService
    {
        public void Add(int listId, TodoItem todoItem);
        public void UpdateTodoItem(TodoItem todoItem);
        public void Delete(int listId, TodoItem todoItem);
        public List<TodoTag> GetAllTags();
        public void AddTagOptions(List<TodoTag> newTags);
        public void RemoveTagOptions(List<TodoTag> newTags);
        public TodoList GetTodoList(int listId);
        public StatusList GetStatusOptions();
        public void UpdateStatusOptions(StatusList options);

    }
}
