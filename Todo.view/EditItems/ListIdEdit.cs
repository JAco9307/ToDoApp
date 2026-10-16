using Todo.view.Entities;
using Todo.view.Interfaces;

namespace Todo.view.OptionsItems
{
    public partial class ListIdEdit : UserControl, ITodoPropertyEdit
    {
        public ListIdEdit(ContextData _context, TodoData _todoData)
        {
            InitializeComponent();
            listComboBox.Items.AddRange(_context.ListNames.ToArray());
            listComboBox.SelectedItem = _todoData.ListTitle;
        }

        public TodoData UpdateData(TodoData todoData)
        {
            if (listComboBox.SelectedItem == null) return todoData;
            string? listname = listComboBox.SelectedItem.ToString();
            if (listname != null)
                todoData.ListTitle = listname;
            return todoData;
        }
    }
}
