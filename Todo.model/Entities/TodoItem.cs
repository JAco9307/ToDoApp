namespace Todo.model.Entities
{
    public class TodoItem
    {
        public int Id { get; private set; }
        public int ListId { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Status Status { get; private set; }
        public List<TodoTag> Tags {  get; private set; } = new List<TodoTag>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItem"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description</param>
        /// <param name="Status">The status.</param>
        public TodoItem(string title, string description= "")
        {
            Title = title;
            Description = description;
        }

        /// <summary>
        /// Sets the todo title.
        /// </summary>
        /// <param name="title">The title.</param>
        public void SetTodoTitle(string title)
        {
            Title = title;
        }

        public void setTags(List<TodoTag> tags)
        {
            Tags = tags;
        }

        public void SetStatus(Status status)
        {
            Status = status;
        }

        public void SetStatus(string status)
        {
            Status = new Status(status);
        }

        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
