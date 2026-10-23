using Todo.view.Entities;
using Todo.view.Interfaces;

namespace Todo.view.EditItems
{
    public partial class StatusEdit : UserControl, ITodoPropertyEdit
    {
        StatusData Status;
        public StatusEdit(TodoData todoData, ContextData context)
        {
            InitializeComponent();
            StatusComboBox.Items.AddRange(context.StatusOptions.ToArray());
            if (todoData.Status.Title == null)
            {
                StatusComboBox.SelectedItem = context.StatusOptions[0];
                Status = context.StatusOptions[0];
            }
            else
            {
                StatusComboBox.SelectedItem = todoData.Status;
                Status = todoData.Status;
            }
        }

        public TodoData UpdateData(TodoData todoData)
        {
            if (StatusComboBox.SelectedItem == null) return todoData;
            Status.Title = StatusComboBox.SelectedItem.ToString();
            if (Status.Title == null) return todoData;
            todoData.Status = Status;
            return todoData;
        }
    }
}
