using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows;

namespace Todo.view
{
    public partial class TodoViewItem : UserControl
    {
        public event EventHandler delete = default;
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoViewItem"/> class.
        /// </summary>
        /// <param name="TodoTitle">The todo title.</param>
        public TodoViewItem(string TodoTitle)
        {
            InitializeComponent();
            todoText.Text = TodoTitle;
        }

        public int id;

        private void deleteTodoButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure to delete this item ??", "Confirm Delete!!", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                delete(this, new EventArgs());
            }
        }

        public Button editButton => editTodoButton;
    }
}
