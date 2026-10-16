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
            get { return _Status; }
            set
            {
                _Status = value;
                CycleStatus.Text = value;
            }
        }
        private string _Status;


        /// <summary>
        /// Initializes a new instance of the <see cref="TodoViewItem"/> class.
        /// </summary>
        /// <param name="TodoTitle">The todo title.</param>
        public TodoViewItem(string TodoTitle, string Status)
        {
            InitializeComponent();

            _Status = Status;
            CycleStatus.Text = Status;
            todoLabel.Text = TodoTitle;
        }

        public Button CycleStatus => StatusButton;

    }
}
