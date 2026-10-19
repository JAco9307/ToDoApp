using Todo.view.Entities;
using Todo.view.Interfaces;
using Todo.view.ViewObjects;

namespace Todo.view
{
    public partial class TodoView : Form, ITodoView
    {
        private Thread? guiThread;

        private Dictionary<string, Comparison<TodoViewItem>> _sortingOptions = [];

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
                listComboBox,
                SortingDropDown,
                SortOrderCheckBox,
                ];

            SetupSortingOptions();

            return controls;
        }

        /// <summary>
        /// Populates the _sortingOptions dictionary names and method of sorting methods that can be used on TodoViewItems.
        /// Then populates the combobox with the name and sets the first index to be selected.
        /// </summary>
        private void SetupSortingOptions()
        {
            _sortingOptions = new Dictionary<string, Comparison<TodoViewItem>>
            {
                { "Name", TodoViewItem.CompareByTitle },
                { "Status", TodoViewItem.CompareByStatus }
            };
            SortingDropDown.DataSource = _sortingOptions.Keys.ToList();
            SortingDropDown.SelectedItem = SortingDropDown.Items[0];
        }

        private void FormThread()
        {
            Application.Run(this);
        }

        //interface
        public List<TodoViewItem> UpdateActiveViewList(List<TodoData> todoDatas)
        {
            Invoke(() => flowLayout.Controls.Clear());
            List<TodoViewItem> controls = [];
            for (int i = 0; i < todoDatas.Count; i++)
            {
                TodoViewItem newTodo = addTodo(todoDatas[i]);
                newTodo.id = i;
                controls.Add(newTodo);
            }
            Invoke(() => SortTodoViewItems(controls));
            Invoke(() => flowLayout.Controls.AddRange(controls.ToArray<Control>()));
            return controls;
        }

        /// <summary>
        /// Sorts the list of TodoViewItems in place, based on the sorting method and reverse selection of the UI 
        /// </summary>
        /// <param name="todoViewItems">List of TodoViewItems to be sorted</param>
        private void SortTodoViewItems(List<TodoViewItem> todoViewItems)
        {
            var selectedItem = SortingDropDown.SelectedItem;
            if (_sortingOptions.ContainsKey(selectedItem?.ToString() ?? ""))
            {
                Comparison<TodoViewItem> sortingOption = _sortingOptions[selectedItem?.ToString() ?? ""];
                todoViewItems.Sort(sortingOption);
                if (SortOrderCheckBox.Checked) todoViewItems.Reverse();
            }
        }

        /// <summary>
        /// Adds a <see cref="TodoViewItem"/> to the GUI.
        /// </summary>
        /// <param name="todoData">the TodoData to populate the TodoViewItem</param>
        /// <returns>The todo view item that has been generated.</returns>
        private TodoViewItem addTodo(TodoData todoData)
        {
            TodoViewItem item = new TodoViewItem(todoData);
            return item;
        }

        //interface
        public TodoData ShowEditTodoDialog(ContextData context, TodoData currentData, bool IsNew)
        {
            EditTodoForm CreateTodoForm = new(context, currentData, IsNew);
            DialogResult result = CreateTodoForm.ShowDialog();
            TodoData todoData = CreateTodoForm.todoData;

            if (result == DialogResult.Cancel && IsNew)
                todoData.ToBeDeleted = true;

            return todoData;
        }

        //interface
        public TodoOptions ShowOptionsMenu(TodoOptions currentOptions)
        {
            OptionsForm OptionsForm = new OptionsForm(currentOptions);
            DialogResult result = OptionsForm.ShowDialog();

            if (result == DialogResult.OK)
                return OptionsForm.OutputOptions;
            else
                return currentOptions;
        }

        //interface
        public void UpdateComboboxLists(List<string> strings, string selectList)
        {
            Invoke(() =>
            {
                listComboBox.Items.Clear();
                listComboBox.Items.AddRange(strings.ToArray());
                listComboBox.SelectedItem = selectList;
            });
        }
    }
}
