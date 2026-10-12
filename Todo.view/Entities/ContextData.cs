using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.view.Entities
{
    public struct ContextData
    {
        public string Title { get; private set; }
        public List<(string, Color)> CurrentTags { get; private set; }
        public List<(string, Color)> AllTags { get; private set; }

        public ContextData(string title, List<(string, Color)> currentTags, List<(string, Color)> allTags)
        {
            Title = title;
            CurrentTags = currentTags;
            AllTags = allTags;
        }
    }
}
