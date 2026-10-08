namespace Todo.view
{
    public partial class EditTodoForm : Form
    {
        public string Titlestr;

        public event EventHandler? Delete = default;
        public EditTodoForm(string titlestr = "")
        {
            InitializeComponent();
            Titlestr = titlestr;
            titleTextBox.Text = Titlestr;
            titleTextBox.Select();
        }
        public void cancelClick(object sender, EventArgs e) 
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        public void saveClick(object sender, EventArgs e) 
        {
            Titlestr = titleTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (Delete != null && confirmResult == DialogResult.Yes)
            {
                Delete(this, new EventArgs());
            }
            Close();
        }
    }
}
