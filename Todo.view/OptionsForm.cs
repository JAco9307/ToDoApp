using System;
using System.Collections;
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
    public partial class OptionsForm : Form
    {
        public TodoOptions OutputOptions;
        public OptionsForm(TodoOptions currentOptions)
        {
            InitializeComponent();
            OutputOptions = currentOptions;
            statusOptionsTextBox.Text = string.Join(",", currentOptions.Status);
        }

        public void cancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public void saveClick(object sender, EventArgs e)
        {
            if (statusOptionsTextBox.Text == "") return;
            try
            {
                string status = statusOptionsTextBox.Text;
                List<string> result = status.Split(new char[] { ',' }).ToList();
                OutputOptions.Status = result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
