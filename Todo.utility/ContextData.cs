using System.Drawing;

namespace Todo.utility
{
    /// <summary>
    /// Represents the <see cref="ContextData"/> struct.
    /// </summary>
    public struct ContextData
    {
        public List<StatusData> StatusOptions;
        public List<string> ListNames;
        public List<(string, Color)> AllTags;
    }
}
