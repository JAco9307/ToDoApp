using Todo.view.Entities;

namespace Todo.view
{
    public partial class EditTodoForm : Form
    {
        public string? Titlestr;
        public string? Description;
        public string Status;
        public EditTodoForm(ContextData context, TodoData todoData)
        {
            InitializeComponent();
            Titlestr = todoData.title;
            Description = todoData.description;

            titleTextBox.Text = Titlestr;
            DescriptionTextBox.Text = Description;
            titleTextBox.Select();
            statusComboBox.Items.AddRange(context.StatusOptions.ToArray());
            if (todoData.status == null)
            {
                statusComboBox.SelectedItem = context.StatusOptions[0];
                Status = context.StatusOptions[0];
            }
            else
            {
                statusComboBox.SelectedItem = todoData.status;
                Status = todoData.status;
            }
        }
        
        public void cancelClick(object sender, EventArgs e)
        {
            Titlestr = null;
            this.Close();
        }
        
        public void saveClick(object sender, EventArgs e)
        {
            if (statusComboBox.SelectedItem == null) return;
            if (titleTextBox.Text == "") return;
            Titlestr = titleTextBox.Text;
            Description = DescriptionTextBox.Text;
            Status = statusComboBox.Text;
            this.Close();
        }
    }
}
