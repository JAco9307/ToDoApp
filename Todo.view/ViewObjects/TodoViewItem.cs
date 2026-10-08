namespace Todo.view
{
    public partial class TodoViewItem : UserControl
    {
        public int id;
        public Label TodoLabel => todoLabel;
        public event EventHandler? Delete = default;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoViewItem"/> class.
        /// </summary>
        /// <param name="TodoTitle">The todo title.</param>
        public TodoViewItem(string TodoTitle)
        {
            InitializeComponent();
            todoLabel.Text = TodoTitle;
        }
        
        private void deleteTodoButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (Delete != null && confirmResult == DialogResult.Yes)
            {
                Delete(this, new EventArgs());
            }
        }
    }
}
