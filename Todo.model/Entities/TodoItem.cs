using System.Text.Json.Serialization;

namespace Todo.model.Entities
{
    public class TodoItem
    {
        public int Id { get; private set; }
        public int ListId { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public List<TodoTag> Tags { get; private set; } = new List<TodoTag>();

        public TodoItem()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItem"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description</param>
        /// <param name="Status">The status.</param>
        public TodoItem(string title, Status status, string description = "")
        {
            Title = title;
            Description = description;
        }

        [JsonConstructor]
        public TodoItem(string title, string description, Status status, List<TodoTag> tags)
        {
            Title = title;
            Description = description;
            Status = status;
            Tags = tags;
        }

        /// <summary>
        /// Sets the todo title.
        /// </summary>
        /// <param name="title">The title.</param>
        public void SetTodoTitle(string title)
        {
            Title = title;
        }

        /// <summary>
        /// Sets the tags.
        /// </summary>
        /// <param name="tags">The tags.</param>
        public void SetTags(List<TodoTag> tags)
        {
            Tags = tags ?? new List<TodoTag>();
        }

        /// <summary>
        /// Sets the todo status.
        /// </summary>
        /// <param name="status">The status.</param>
        public void SetTodoStatus(Status status)
        {
            Status = status;
        }

        /// <summary>
        /// Sets the description.
        /// </summary>
        /// <param name="description">The description.</param>
        public void SetDescription(string description)
        {
            Description = description;
        }
    }
}
