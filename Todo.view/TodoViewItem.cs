using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Todo.view
{
    public partial class TodoViewItem : UserControl
    {
        public TodoViewItem()
        {
            InitializeComponent();
        }

        public TextBox textBox { get { return todoText; } }
        public Button deleteButton { get { return deleteTodoButton; } }
    }
}
