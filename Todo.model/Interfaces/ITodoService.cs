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
        public void RenameList(string TitleOld, string TitleNew);
        public List<TodoTag> GetAllTags();
        public void AddTagOptions(List<TodoTag> newTags);
        public void RemoveTagOptions(List<TodoTag> newTags);
        public StatusList GetStatusOptions();
        public TodoList GetTodoList(int listId);
        public TodoList GetTodoList(string listTitle);
        public List<string> GetListNames();
    }
}
