using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface ITodoRepository
    {
        public TodoList? GetList(int TodoListId);
        public void AddTodoItem(TodoItem todoItem);
        public void DeleteTodoItem(TodoItem todoItem);
        public List<TodoTag>? GetAllTags();
        public void AddTagOptions(List<TodoTag> newTags);
        public void RemoveTagOptions(List<TodoTag> newTags);
        public StatusList? GetStatusOptions();
        public void UpdateDb();

    }
}
