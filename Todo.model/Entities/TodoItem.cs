namespace Todo.model.Entities
{
    public class TodoItem
    {
        public int Id { get; private set; }
        public int ListId { get; set; }
        public string Title { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItem"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        public TodoItem(string title)
        {
            Title = title;
        }

        /// <summary>
        /// Sets the todo title.
        /// </summary>
        /// <param name="title">The title.</param>
        public void SetTodoTitle(string title)
        {
            Title = title;
        }
    }
}
