using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.view.Entities
{
 
    /// <summary>
    /// A struct for containing the values of a todo item.
    /// </summary>
    public struct TodoData
    {
        public string? Title;
        public string Status;
        public List<(string, Color)> CurrentTags;
    }
}
