using Todo.view.Entities;

namespace Todo.view
{
    public partial class EditTodoForm : Form
    {
        public TodoData Result;
        public event EventHandler? Delete = default;
        
        public EditTodoForm(ContextData context, TodoData todoData)
        {
            InitializeComponent();
            titleTextBox.Text = todoData.title;
            titleTextBox.Select();
            statusComboBox.Items.AddRange(context.StatusOptions.ToArray());
            if (todoData.status == null)
            {
                statusComboBox.SelectedItem = context.StatusOptions[0];
            }
            else
            {
                statusComboBox.SelectedItem = todoData.status;
            }


        }
        public void cancelClick(object sender, EventArgs e)
        {
            Result.title = null;
            this.Close();
        }
        public void saveClick(object sender, EventArgs e)
        {
            if (statusComboBox.SelectedItem == null) return;
            if (titleTextBox.Text == "") return;
            Result.title = titleTextBox.Text;
            Result.status = statusComboBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Result.ToBeDeleted = true;
                Close();
            }
        }
    }
}
