
using Todo.view.Interfaces;
namespace Todo.view
{
    public partial class TodoView : Form, ITodoView
    {
        private Thread guiThread;
        public TodoView()
        {
            InitializeComponent();
        }

        public List<Control> StartUp()
        {
            guiThread = new Thread(FormThread);
            guiThread.SetApartmentState(ApartmentState.STA);
            guiThread.Start();

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
            int i = 0;
            foreach (string itemTitle in todoTitles) 
            {
                TodoViewItem newTodo = addTodo(itemTitle);
                newTodo.id = i++;
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
            Invoke(() => flowLayout.Controls.Add(item));
            return item;
        }

        public PopupResult ShowEditTodoDialog(string currentTitle)
        {
            EditTodoForm CreateTodoForm = new EditTodoForm(currentTitle);
            DialogResult result = CreateTodoForm.ShowDialog();

            return new PopupResult
            {
                dialogResult = result,
                title = CreateTodoForm.Titlestr
            };
        }

    }
}
