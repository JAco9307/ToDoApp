namespace Todo.model.Entities
{
    public class TodoItem
    {
        public int Id { get; private set; }
        public string Title { get; private set; }

        public TodoItem(string title)
        {
            Title = title;
        }

        public void SetTodoTitle(string title)
        {
            Title = title;
        }
    }
}
