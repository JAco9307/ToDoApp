
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

            // foreach (string itemTitle in todoTitles { controls.Add(addTodo(itemTitle) }
            controls.Add(addTodo(todoTitles[0]));

            return controls;
        }

        private TodoViewItem addTodo(string TodoTitle) // takes todoitem
        {
            TodoViewItem item = new TodoViewItem(TodoTitle);
            flowLayout.Controls.Add(item);
            return item;

        }
    }
}
