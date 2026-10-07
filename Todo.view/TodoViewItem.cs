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
        public event EventHandler? Delete = default;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Status
        {
            get { return _status; }
            set {
                _status = value; 
                CycleStatus.Text = value; 
            } 
        }
        private string _status;

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
            DialogResult confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (Delete != null && confirmResult == DialogResult.Yes)
            {
                Delete(this, new EventArgs());
            }
        }

        public Button editButton => editTodoButton;
        public Button CycleStatus => StatusButton;
    }
}
