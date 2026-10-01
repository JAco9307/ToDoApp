
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

        public List<TodoViewItem> UpdateActiveViewList(object? todoList)
        {
            flowLayout.Controls.Clear();
            List<TodoViewItem> controls = new();
            
            // foreach (TodoItem item in todoList { controls.Add(addTodo(item.Title) }
            controls.Add(addTodo("Nothing"));

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
