using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Todo.view.Entities;

namespace Todo.view
{
    public partial class OptionsForm : Form
    {
        public TodoOptions OutputOptions;
        public TextBox statusTextBox => statusOptionsTextBox;


        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsForm"/> class.
        /// </summary>
        /// <param name="currentOptions">The current options.</param>
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


        /// <summary>
        /// Parses the options and closes the dialog.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event.</param>
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
                MessageBox.Show("Cannot parse status options\n" + ex.ToString(), "Error", MessageBoxButtons.OK);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
