using Todo.view.Entities;
using Todo.view.Interfaces;

namespace Todo.view.EditItems
{
    public partial class TitleEdit : UserControl, ITodoPropertyEdit
    {
        public TitleEdit(TodoData todoData)
        {
            InitializeComponent();
            titleTextBox?.Text = todoData.Title;
        }

        public TodoData UpdateData(TodoData todoData)
        {
            if (titleTextBox.Text == "") return todoData;
            todoData.Title = titleTextBox.Text;
            return todoData;
        }
    }
}
