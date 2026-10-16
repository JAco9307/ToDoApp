using Todo.view.Entities;
using Todo.view.Interfaces;

namespace Todo.view.EditItems;

public partial class DescriptionEdit : UserControl, ITodoPropertyEdit
{
    public DescriptionEdit(TodoData todoData)
    {
        InitializeComponent();
        DescriptionTextBox.Text = todoData.Description;
    }

    public TodoData UpdateData(TodoData data)
    {
        data.Description = DescriptionTextBox.Text;
        return data;
    }
}