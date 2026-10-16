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
            get { return _Status; }
            set {
                _Status = value; 
                CycleStatus.Text = value; 
            } 
        }
        private string _Status;


        /// <summary>
        /// Initializes a new instance of the <see cref="TodoViewItem"/> class.
        /// </summary>
        /// <param name="TodoTitle">The todo title.</param>
        public TodoViewItem(TodoData todoData)
        {
            InitializeComponent();

            _Status = todoData.Status;
            CycleStatus.Text = todoData.Status;
            todoLabel.Text = todoData.TodoTitle;
        }
                
        public Button CycleStatus => StatusButton;
    }
}
