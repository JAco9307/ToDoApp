using System.ComponentModel;

namespace Todo.view
{
    public partial class TodoViewItem : UserControl
    {
        public int id;
        public Label TodoLabel => todoLabel;
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
                
        public Button CycleStatus => StatusButton;

        public static int CompareByTitle(TodoViewItem item1, TodoViewItem item2)
        {
            return item1.TodoLabel.Text.CompareTo(item2.todoLabel.Text);
        }
    }
}
