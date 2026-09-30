namespace Todo.formview
{
    public interface ITodoView
    {

        /// <summary>
        /// Updates the active view list.
        /// </summary>
        /// <param name="todoList">The todo list.</param>
        /// <returns>List of each created delete button.</returns>
        public List<Control> UpdateActiveViewList(object todoList);

        /// <summary>
        /// Start the form in a thread.
        /// </summary>
        /// <returns>Returns relevant controls for binding</returns>
        public List<Control> StartUp();

    }

    public partial class FormView : Form, ITodoView
    {
        public FormView()
        {
            InitializeComponent();
        }

        public List<Control> StartUp()
        {
            var newThread = new Thread(FormThread);
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();

            List<Control> controls = [createTodoButton, deleteTodoButton, todoText];
            return controls;
        }

        private void FormThread()
        {
            Application.Run(this);
        }

        public List<Control> UpdateActiveViewList(object todoList)
        {
            return new List<Control>();
        }
    }
}
