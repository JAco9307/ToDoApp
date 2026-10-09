using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Todo.view.Dialogs
{
    public partial class TextInputDialog : Form
    {
        public string text => textBox.Text;
        public TextInputDialog(string header)
        {
            InitializeComponent();
            headerLabel.Text = header;
            textBox.Select();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
        }
    }
}
