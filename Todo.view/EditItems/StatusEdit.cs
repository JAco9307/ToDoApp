using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Todo.view.Entities;
using Todo.view.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Todo.view.EditItems
{
    public partial class StatusEdit : UserControl, ITodoPropertyEdit
    {
        string? Status;
        public StatusEdit(TodoData todoData, ContextData context)
        {
            InitializeComponent();
            statusComboBox.Items.AddRange(context.StatusOptions.ToArray());
            if (todoData.status == null)
            {
                statusComboBox.SelectedItem = context.StatusOptions[0];
                Status = context.StatusOptions[0];
            }
            else
            {
                statusComboBox.SelectedItem = todoData.status;
                Status = todoData.status;
            }
        }

        public TodoData UpdateData(TodoData todoData)
        {
            if (statusComboBox.SelectedItem == null) return todoData;
            Status = statusComboBox.SelectedItem.ToString();
            if (Status == null) return todoData; 
            todoData.status = Status;
            return todoData;
        }
    }
}
