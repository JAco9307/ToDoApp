namespace Todo.model.Entities
{
    public class TodoList
    {
        public int Id { get; private set; }
        private readonly List<TodoItem> _items = new List<TodoItem>();
        public IReadOnlyList<TodoItem> Items => _items;

        public string Title { get; set; }
        
        public TodoList()
        {
            Title = "New List";
        }
        public TodoList(int listId)
        {
            Id = listId;
            Title = "New List";
        }

        /// <summary>
        /// Adds the TodoItem to the TodoList.
        /// </summary>
        /// <param name="item">The TodoItem.</param>
        public void Add(TodoItem item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Removes the TodoItem to the TodoList. Throws KeyNotFoundException if removing fails.
        /// </summary>
        /// <param name="item">The TodoItem.</param>
        public void Remove(TodoItem item)
        {
            bool success = _items.Remove(item);

            if(!success)
                throw new KeyNotFoundException("Given item was not found in the list");
        }
    }
}
