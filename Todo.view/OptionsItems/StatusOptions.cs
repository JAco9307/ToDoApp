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
            statusOptionsTextBox.Text = string.Join(",", currentOptions.Status);
        }

        public TodoOptions Save(TodoOptions currentOptions)
        {
            if (statusOptionsTextBox.Text == "") return currentOptions;
            try
            {
                string status = statusOptionsTextBox.Text;
                List<string> result = status.Split(new char[] { ',' }).ToList();
                currentOptions.Status = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot parse status options\n" + ex.ToString(), "Error", MessageBoxButtons.OK);
            }
            return currentOptions;
        }
    }
}
