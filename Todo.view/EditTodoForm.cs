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
        public EditTodoForm(List<string> statusOptions, string titlestr = "")
        {
            InitializeComponent();
            Titlestr = titlestr;
            titleTextBox.Text = Titlestr;
            titleTextBox.Select();
            comboBox1.Items.AddRange(statusOptions.ToArray());
            comboBox1.SelectedItem = statusOptions[0];
            Status = statusOptions[0];


        }
        public void cancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public void saveClick(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;
            if (titleTextBox.Text == "") return;
            Titlestr = titleTextBox.Text;
            Status = comboBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
