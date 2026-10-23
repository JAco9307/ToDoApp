namespace Todo.view.Entities
{

    /// <summary>
    /// A struct for containing the application settings.
    /// </summary>
    public struct TodoOptions
    {
        public List<string> Status;
        public List<string> ListNames;
        public Dictionary<string,string> ListNameChanges;
        public List<(string,Color)> Tags;
        public bool CreateExport;
        public string ImportFilePath;

    }
}
