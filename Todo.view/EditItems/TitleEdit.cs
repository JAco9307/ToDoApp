using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Todo.view.Entities;
using Todo.view.Interfaces;

namespace Todo.view.EditItems
{
    public partial class TitleEdit : UserControl, ITodoPropertyEdit
    {
        public TitleEdit(TodoData todoData)
        {
            InitializeComponent();
            if(todoData.title != null)
                titleTextBox.Text = todoData.title;
        }

        public TodoData UpdateData(TodoData todoData)
        {
            if (titleTextBox.Text == "") return todoData;
            todoData.title = titleTextBox.Text;
            return todoData;
        }
    }
}
