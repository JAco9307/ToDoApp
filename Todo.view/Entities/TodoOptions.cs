using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.view.Entities
{

    /// <summary>
    /// A struct for containing the application settings.
    /// </summary>
    public struct TodoOptions
    {
        public List<string> Status;
        public List<string> ListNames;
        public string CurrentList;
        public Dictionary<string,string> ListNameChanges;
        public List<(string,Color)> Tags;
        public bool CreateExport;
        public string ImportFilePath;

    }
}
