using Todo.view.Entities;
using Todo.view.Interfaces;
using System.Collections.Generic;

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
                SortingDropDown
                ];
            List<string> sortingOptions = ["Name", "Id"];
            SortingDropDown.Items.AddRange(sortingOptions.ToArray());
            SortingDropDown.SelectedItem = SortingDropDown.Items[0];
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
        public List<TodoViewItem> UpdateActiveViewList(List<TodoData> todoDatas)
        {
            flowLayout.Controls.Clear();
            List<TodoViewItem> controls = [];
            for(int i = 0; i < todoDatas.Count; i++)
            {
                TodoViewItem newTodo = addTodo(todoDatas[i]);
                newTodo.id = i;
                controls.Add(newTodo); 
            }

            switch (SortingDropDown.SelectedIndex)
            {
                case 0:
                    controls.Sort(TodoViewItem.CompareByTitle);
                    if (SortOrderCheckBox.Checked) controls.Reverse();
                    break;
                case 1:
                    controls.Sort(TodoViewItem.CompareByTitle);
                    if (SortOrderCheckBox.Checked) controls.Reverse();
                    break;
            }
            Invoke(() => flowLayout.Controls.AddRange(controls.ToArray()));
            return controls;
        }
        
        /// <summary>
        /// Adds a <see cref="TodoViewItem"/> to the GUI.
        /// </summary>
        /// <param name="TodoTitle">The todo title.</param>
        /// <returns>The todo view item that has been generated.</returns>
        private TodoViewItem addTodo(TodoData todoData)
        {
            TodoViewItem item = new TodoViewItem(todoData);
            //Invoke(() => flowLayout.Controls.Add(item));
            return item;
        }
        
        /// <summary>
        /// Shows an dialog window to create or edit a TodoItem
        /// </summary>
        /// <param name="currentTitle">Title to be filled out if editing and existing item</param>
        /// <returns></returns>
        public TodoData ShowEditTodoDialog(ContextData context, TodoData? currentData)
        {
            bool IsNew = false;
            if (currentData == null)
            {
                currentData = new TodoData();
                IsNew = true;
            }
            
            var CreateTodoForm = new EditTodoForm(context, (TodoData)currentData, IsNew);
            DialogResult result = CreateTodoForm.ShowDialog();

            return CreateTodoForm.todoData;

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
    }
}
