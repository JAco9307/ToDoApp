using System.ComponentModel;

namespace Todo.view
{
    public partial class TodoViewItem : UserControl
    {
        public int id;
        public Label TodoLabel => todoLabel;
        public event EventHandler? Delete = default;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Status
        {
            get { return _status; }
            set {
                _status = value; 
                CycleStatus.Text = value; 
            } 
        }
        private string _status;


        /// <summary>
        /// Initializes a new instance of the <see cref="TodoViewItem"/> class.
        /// </summary>
        /// <param name="TodoTitle">The todo title.</param>
        public TodoViewItem(string TodoTitle, string Status)
        {
            InitializeComponent();

            _status = Status;
            CycleStatus.Text = Status;
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
        
        public Button CycleStatus => StatusButton;

    }
}
