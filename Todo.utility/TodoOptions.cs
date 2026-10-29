using System.Drawing;

namespace Todo.utility

{

    /// <summary>
    /// A struct for containing the application settings.
    /// </summary>
    public struct TodoOptions
    {
        public List<StatusData> Status;
        public List<string> ListNames;
        public Dictionary<string,string> ListNameChanges;
        public List<(string,Color)> Tags;
        public bool CreateExport;
        public string ImportFilePath;

    }
}
