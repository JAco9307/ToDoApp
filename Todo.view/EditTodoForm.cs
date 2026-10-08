using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Todo.view
{
    public partial class EditTodoForm : Form
    {
        public string Titlestr;
        public string Status;
        public EditTodoForm(List<string> statusOptions, string titlestr = "", string selectedStatus = "")
        {
            InitializeComponent();
            Titlestr = titlestr;
            titleTextBox.Text = Titlestr;
            titleTextBox.Select();
            statusComboBox.Items.AddRange(statusOptions.ToArray());
            if (selectedStatus == "")
            {
                statusComboBox.SelectedItem = statusOptions[0];
                Status = statusOptions[0];
            }
            else
            {
                statusComboBox.SelectedItem = selectedStatus;
                Status = selectedStatus;
            }


        }
        public void cancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public void saveClick(object sender, EventArgs e)
        {
            if (statusComboBox.SelectedItem == null) return;
            if (titleTextBox.Text == "") return;
            Titlestr = titleTextBox.Text;
            Status = statusComboBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
