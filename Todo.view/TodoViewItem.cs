namespace Todo.view
{
    public partial class TodoViewItem : UserControl
    {
        public int id;
        public Label TodoLabel => todoLabel;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoViewItem"/> class.
        /// </summary>
        /// <param name="TodoTitle">The todo title.</param>
        public TodoViewItem(string TodoTitle)
        {
            InitializeComponent();
            todoLabel.Text = TodoTitle;
        }
    }
}
