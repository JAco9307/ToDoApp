using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface ITodoRepository
    {
        public TodoList? GetList(int TodoListId);
        public TodoList? GetList(string TodoListTitle);
        public void AddTodoItem(TodoItem todoItem, int listId);
        public TodoList AddList(string Title);
        public void DeleteTodoItem(TodoItem todoItem);
        public void DeleteList(TodoList list);
        public List<TodoTag>? GetAllTags();
        public void AddTagOptions(List<TodoTag> newTags);
        public void RemoveTagOptions(List<TodoTag> newTags);
        public List<Status> GetStatusOptions();
        public void UpdateDb();
        public List<string> GetListNames();
        public List<TodoList> GetLists();

    }
}
