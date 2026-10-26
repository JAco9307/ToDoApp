using System.Data;
using Todo.utility;
using Todo.view.Interfaces;
using Todo.view.ViewObjects;

namespace Todo.view.EditItems
{
    public partial class TagsEdit : UserControl, ITodoPropertyEdit
    {
        public List<(string, Color)> CurrentTags;
        public List<(string, Color)> AllTags;
        public TagsEdit(TodoData todoData, ContextData context)
        {
            InitializeComponent();

            CurrentTags = todoData.CurrentTags;
            AllTags = context.AllTags;

            CurrentTagsFlowLayout.Controls.Clear();
            foreach ((string title, Color color) tag in todoData.CurrentTags)
            {
                CurrentTagsFlowLayout.Controls.Add(new TodoViewTag(tag.title, tag.color));
            }

            AddTagsComboBox.Items.AddRange(context.AllTags.Select(tag => tag.Item1).ToArray());
        }

        public TodoData UpdateData(TodoData data)
        {
            data.CurrentTags = new List<(string, Color)>();

            foreach (TodoViewTag viewTag in CurrentTagsFlowLayout.Controls)
            {
                data.CurrentTags.Add(viewTag.getTag());
            }

            return data;
        }

        public void TagsComboBoxSelectionChanged(object sender, EventArgs e)
        {
            if (CurrentTags == null)
                throw new NullReferenceException();

            if (AddTagsComboBox.SelectedItem is not string)
                return;
            string selectedItem = (string)AddTagsComboBox.SelectedItem;

            (string title, Color color) tag = AllTags.First(tag => tag.Item1 == selectedItem);
            TodoViewTag viewTag = new TodoViewTag(tag.title, tag.color);

            CurrentTagsFlowLayout.Controls.Add(viewTag);

            viewTag.Delete += delegate { AddTagsComboBox.Items.Add(tag.title); };

            CurrentTags.Add(AllTags.FirstOrDefault(tag => tag.Item1 == selectedItem));

            AddTagsComboBox.Items.Remove(selectedItem);
        }
    }
}
