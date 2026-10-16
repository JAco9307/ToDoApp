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
        /// <param name="todoStatus">The todo Status.</param>
        /// <returns>The list result.</returns>
        public List<TodoViewItem> UpdateActiveViewList(List<string> todoTitles, List<string> todoStatus)
        {
            Invoke(()=> flowLayout.Controls.Clear());
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
        /// <param name="Status">The todo status.</param>
        /// <returns>The todo view item that has been generated.</returns>
        private TodoViewItem addTodo(string TodoTitle, string Status)
        {
            TodoViewItem item = new TodoViewItem(TodoTitle, Status);
            Invoke(() => flowLayout.Controls.Add(item));
            return item;
        }

        /// <summary>
        /// Shows an dialog window to create or edit a TodoItem
        /// </summary>
        /// <param name="context">The context data</param>
        /// <param name="currentData">The current todo data if applicable</param>
        /// <returns></returns>
        public TodoData ShowEditTodoDialog(ContextData context, TodoData currentData, bool IsNew)
        {
            var CreateTodoForm = new EditTodoForm(context, currentData, IsNew);
            DialogResult result = CreateTodoForm.ShowDialog();
            TodoData todoData = CreateTodoForm.todoData;
            if (result == DialogResult.Cancel)
            {
                todoData.ToBeDeleted = true;
            }

            return todoData;
        }

        /// <summary>
        /// Opens the options form and recieves the data in it afterwards.
        /// </summary>
        /// <param name="currentOptions">The current options.</param>
        /// <returns>The options set when saving.</returns>
        public TodoOptions ShowOptionsMenu(TodoOptions currentOptions)
        {
            OptionsForm OptionsForm = new OptionsForm(currentOptions);
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
