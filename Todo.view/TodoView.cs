
using Todo.view.Entities;
using Todo.view.Interfaces;
namespace Todo.view
{
    public partial class TodoView : Form, ITodoView
    {
        private Thread? guiThread;
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
                optionsButton
                ];

            return controls;
        }

        private void FormThread()
        {
            Application.Run(this);
        }

        public List<TodoViewItem> UpdateActiveViewList(List<string> todoTitles, List<string> todoStatus)
        {
            flowLayout.Controls.Clear();
            List<TodoViewItem> controls = new();
            for(int i = 0; i < todoTitles.Count; i++)
            {
                TodoViewItem newTodo = addTodo(todoTitles[i], todoStatus[i]);
                newTodo.id = i;
                controls.Add(newTodo); 
            }

            return controls;
        }

        /// <summary>
        /// Adds a <see cref="TodoViewItem"/> to the GUI.
        /// </summary>
        /// <param name="TodoTitle">The todo title.</param>
        /// <returns>The todo view item that has been generated.</returns>
        private TodoViewItem addTodo(string TodoTitle, string Status)
        {
            TodoViewItem item = new TodoViewItem(TodoTitle, Status);
            Invoke(() => flowLayout.Controls.Add(item));
            return item;
        }

        public PopupResult ShowEditTodoDialog(List<string> statusOptions, string currentTitle)
        {
            var CreateTodoForm = new EditTodoForm(statusOptions,currentTitle);
            DialogResult result = CreateTodoForm.ShowDialog();

            return new PopupResult
            {
                dialogResult = result,
                title = CreateTodoForm.Titlestr,
                status = CreateTodoForm.Status  
            };
        }

        public TodoOptions ShowOptionsMenu(TodoOptions currentOptions)
        {
            var OptionsForm = new OptionsForm(currentOptions);
            DialogResult result = OptionsForm.ShowDialog();
            if (result == DialogResult.OK)
                return OptionsForm.OutputOptions;
            else
                return currentOptions;
        }
    }
}
