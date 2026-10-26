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
            
            List<StatusData> statusDatas = context.StatusOptions;
            foreach (var statusData in statusDatas)
            {
                StatusComboBox.Items.Add(statusData);
            }
            
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
            Status = (StatusData)StatusComboBox.SelectedItem;
            if (Status.Title == null) return todoData;
            todoData.Status = Status;
            return todoData;
        }
    }
}
