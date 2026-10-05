
using Todo.view.Interfaces;
namespace Todo.view
{
    public partial class TodoView : Form, ITodoView
    {
        public TodoView()
        {
            InitializeComponent();
        }

        public List<Control> StartUp()
        {
            var newThread = new Thread(FormThread);
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();

            List<Control> controls = [
                createTodoButton, 
                ];

            return controls;
        }

        private void FormThread()
        {
            Application.Run(this);
        }

        public List<TodoViewItem> UpdateActiveViewList(List<string> todoTitles)
        {
            flowLayout.Controls.Clear();
            List<TodoViewItem> controls = new();

            foreach (string itemTitle in todoTitles) 
            {
                TodoViewItem newTodo = addTodo(itemTitle);
                controls.Add(newTodo); 
            }

            return controls;
        }

        /// <summary>
        /// Adds a <see cref="TodoViewItem"/> to the GUI.
        /// </summary>
        /// <param name="TodoTitle">The todo title.</param>
        /// <returns>The todo view item that has been generated.</returns>
        private TodoViewItem addTodo(string TodoTitle)
        {
            TodoViewItem item = new TodoViewItem(TodoTitle);
            flowLayout.Controls.Add(item);
            return item;
        }

        public PopupResult GetPopupResult(string currentTitle)
        {
            var CreateTodoForm = new EditTodoForm(currentTitle);
            var result = CreateTodoForm.ShowDialog();

            return new PopupResult
            {
                dialogResult = result,
                title = CreateTodoForm.Titlestr
            };
        }

    }
}
