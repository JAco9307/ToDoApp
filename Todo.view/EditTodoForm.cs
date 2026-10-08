using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Todo.view.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Todo.view
{
    public partial class EditTodoForm : Form
    {
        public string? Titlestr;
        public string Status;
        public EditTodoForm(List<string> statusOptions, TodoData todoData)
        {
            InitializeComponent();
            Titlestr = todoData.title;

            titleTextBox.Text = Titlestr;
            titleTextBox.Select();
            statusComboBox.Items.AddRange(statusOptions.ToArray());
            if (todoData.status == "")
            {
                statusComboBox.SelectedItem = statusOptions[0];
                Status = statusOptions[0];
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
            this.Close();
        }
    }
}
