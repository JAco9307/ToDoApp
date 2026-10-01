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

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoViewItem"/> class.
        /// </summary>
        /// <param name="TodoTitle">The todo title.</param>
        public TodoViewItem(string TodoTitle)
        {
            InitializeComponent();
            textBox.Text = TodoTitle;
        }

        public TextBox textBox => todoText;
        public Button deleteButton => deleteTodoButton; 
        public Button editButton => editTodoButton; 
    }
}
