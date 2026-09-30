namespace Todo.formview
{
    public interface ITodoView
    {
        public void UpdateActiveViewList(object todoList);

    }

    public partial class FormView : Form, ITodoView
    {
        public FormView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the active view list.
        /// </summary>
        /// <param name="todoList">The todo list to display.</param>
        public void UpdateActiveViewList(object todoList)
        {

        }
    }
}
