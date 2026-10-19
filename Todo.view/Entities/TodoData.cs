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
    }
}
