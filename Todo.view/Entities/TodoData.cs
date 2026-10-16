namespace Todo.view.Entities
{
 
    /// <summary>
    /// A struct for containing the values of a todo item.
    /// </summary>
    public struct TodoData
    {
        public string? Title;
        public string Status;
        public string ListTitle;
        public string Description;

        public bool ToBeDeleted;

        public List<(string, Color)> CurrentTags;
        
        public static int CompareByTitle(TodoData item1, TodoData item2)
        {
            return String.Compare(item1.title, item2.title, StringComparison.Ordinal);
        }

        public static int CompareByStatus(TodoData item1, TodoData item2)
        {
            return String.Compare(item1.status, item2.status, StringComparison.Ordinal);
        }
    }
}
