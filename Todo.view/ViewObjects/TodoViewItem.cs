using System.ComponentModel;
using Todo.view.Entities;

namespace Todo.view.ViewObjects
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
        public TodoViewItem(TodoData todoData)
        {
            InitializeComponent();

            _status = todoData.status;
            CycleStatus.Text = todoData.status;
            todoLabel.Text = todoData.title;
        }
                
        public Button CycleStatus => StatusButton;
    }
}
