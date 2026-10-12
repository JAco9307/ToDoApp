using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.view.Entities
{
    public struct ContextData
    {
        public List<string> StatusOptions;
        public List<(string, Color)> AllTags;
    }
}
