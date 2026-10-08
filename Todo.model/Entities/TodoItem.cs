namespace Todo.model.Entities
{
    public class TodoItem
    {
        public int Id { get; private set; }
        public int ListId { get; set; }
        public string Title { get; private set; }
        public string Status { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItem"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="Status">The status.</param>
        public TodoItem(string title, string status = "Not Started")
        {
            Title = title;
            Status = status;
        }

        /// <summary>
        /// Sets the todo title.
        /// </summary>
        /// <param name="title">The title.</param>
        public void SetTodoTitle(string title)
        {
            Title = title;
        }

        public void SetTodoStatus(string status)
        {
            Status = status;
        }
    }
}
