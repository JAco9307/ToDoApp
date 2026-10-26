using Todo.DTOs;
using Todo.view.Interfaces;
using Todo.view.ViewObjects;

namespace Todo.view.OptionsItems
{
    public partial class TagsOptions : UserControl, IOption
    {
        public TagsOptions(TodoOptions currentOptions)
        {
            InitializeComponent();
            TagsFlowLayoutPanel.Controls.Clear();
            foreach ((string title, Color color) tag in currentOptions.Tags)
            {
                TagsFlowLayoutPanel.Controls.Add(new TodoViewTag(tag.title, tag.color));
            }
        }

        public TodoOptions Save(TodoOptions currentOptions)
        {
            try
            {
                currentOptions.Tags.Clear();
                foreach (TodoViewTag viewTag in TagsFlowLayoutPanel.Controls)
                {
                    currentOptions.Tags.Add(viewTag.getTag());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot parse tags options\n" + ex.ToString(), "Error", MessageBoxButtons.OK);
            }
            return currentOptions;
        }

        private void AddTagButton_Click(object sender, EventArgs e)
        {
            TagsFlowLayoutPanel.Controls.Add(new TodoViewTag("", Color.White));
        }
    }
}
