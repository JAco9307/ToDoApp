using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Todo.view.Entities;
using Todo.view.Interfaces;
using Todo.view.OptionsItems;

namespace Todo.view
{
    public partial class OptionsForm : Form
    {
        public TodoOptions OutputOptions;
        List<IOption> OptionItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsForm"/> class.
        /// </summary>
        /// <param name="currentOptions">The current options.</param>
        public OptionsForm(TodoOptions currentOptions)
        {
            InitializeComponent();
            OutputOptions = currentOptions;
            OptionItems = new List<IOption>
            {
                new StatusOptions(currentOptions),
                new ListNameOptions(currentOptions)
            };
            foreach (IOption OptionItem in OptionItems)
            {
                flowLayoutPanel.Controls.Add((Control)OptionItem);
            }
                      
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
            foreach (IOption option in OptionItems) 
            {
                OutputOptions = option.Save(OutputOptions);
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
