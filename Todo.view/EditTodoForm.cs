using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Todo.view
{
    public partial class EditTodoForm : Form
    {
        public string Titlestr = "";
        public EditTodoForm()
        {
            InitializeComponent();
            titleTextBox.Select();
        }
        public void cancelClick(object sender, EventArgs e) 
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public void saveClick(object sender, EventArgs e) 
        {
            Titlestr = titleTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
