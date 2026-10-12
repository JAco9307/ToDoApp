using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Todo.view.Entities;

namespace Todo.view
{
    public partial class EditTodoForm : Form
    {
        public string? Titlestr;
        public string Status;
        public event EventHandler? Delete = default;
        
        public EditTodoForm(ContextData context, TodoData todoData)
        {
            InitializeComponent();
            Titlestr = todoData.title;

            titleTextBox.Text = Titlestr;
            titleTextBox.Select();
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
        public void cancelClick(object sender, EventArgs e)
        {
            Titlestr = null;
            this.Close();
        }
        public void saveClick(object sender, EventArgs e)
        {
            if (statusComboBox.SelectedItem == null) return;
            if (titleTextBox.Text == "") return;
            Titlestr = titleTextBox.Text;
            Status = statusComboBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (Delete != null && confirmResult == DialogResult.Yes)
            {
                Delete(this, new EventArgs());
            }
            Close();
        }
    }
}
