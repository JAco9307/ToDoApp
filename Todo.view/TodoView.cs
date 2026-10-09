
using System.Web;
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
                optionsButton,
                listComboBox
                ];

            return controls;
        }

        private void FormThread()
        {
            Application.Run(this);
        }

        /// <summary>
        /// Updates the active view list.
        /// </summary>
        /// <param name="todoTitles">The todo titles.</param>
        /// <param name="todoStatus">The todo status.</param>
        /// <returns>The list result.</returns>
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

        public TodoData ShowEditTodoDialog(ContextData context, TodoData? currentData)
        {
            if (currentData == null)
            {
                currentData = new TodoData();
            }
            var CreateTodoForm = new EditTodoForm(context, (TodoData)currentData);
            DialogResult result = CreateTodoForm.ShowDialog();

            return new TodoData
            {
                title = CreateTodoForm.Titlestr,
                status = CreateTodoForm.Status  
            };
        }

        /// <summary>
        /// Opens the options form and recieves the data in it afterwards.
        /// </summary>
        /// <param name="currentOptions">The current options.</param>
        /// <returns>The options set when saving.</returns>
        public TodoOptions ShowOptionsMenu(TodoOptions currentOptions)
        {
            var OptionsForm = new OptionsForm(currentOptions);
            DialogResult result = OptionsForm.ShowDialog();
            if (result == DialogResult.OK)
                return OptionsForm.OutputOptions;
            else
                return currentOptions;
        }

        public void UpdateLists(List<string> strings, string selectList)
        {
            Invoke(() => { 
                listComboBox.Items.Clear();
                listComboBox.Items.AddRange(strings.ToArray());
                listComboBox.SelectedItem = selectList;
            });
        }
    }
}
