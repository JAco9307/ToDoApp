using System.Drawing;

namespace Todo.model.Entities
{
    public class TodoTag
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = "";
        public Color Color { get; private set; }

        private TodoTag() { }
        public TodoTag(string title, Color color)
        {
            Title = title;
            Color = color;
        }
    }
}
