using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Todo.view.Entities;
using Todo.view.Interfaces;

namespace Todo.view.OptionsItems
{
    public partial class StatusOptions : UserControl, IOption
    {
        public StatusOptions(TodoOptions currentOptions)
        {
            InitializeComponent();
            StatusOptionsTextBox.Text = string.Join(",", currentOptions.Status);
        }

        public TodoOptions Save(TodoOptions currentOptions)
        {
            if (StatusOptionsTextBox.Text == "") return currentOptions;
            try
            {
                string Status = StatusOptionsTextBox.Text;
                List<string> result = Status.Split(new char[] { ',' }).ToList();
                currentOptions.Status = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot parse Status options\n" + ex.ToString(), "Error", MessageBoxButtons.OK);
            }
            return currentOptions;
        }
    }
}
