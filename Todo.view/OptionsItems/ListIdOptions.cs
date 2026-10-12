using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Todo.view.Dialogs;
using Todo.view.Entities;
using Todo.view.Interfaces;

namespace Todo.view.OptionsItems
{
    // not implemented until changes to editform are implemented
    public partial class ListIdOptions : UserControl, IOption 
    {
        public ListIdOptions(TodoOptions currentOptions)
        {
            InitializeComponent();
            listComboBox.Items.AddRange(currentOptions.ListNames.ToArray());
            listComboBox.SelectedText = currentOptions.CurrentList;
        }

        public TodoOptions Save(TodoOptions currentOptions)
        {
            if (listComboBox.SelectedItem == null) return currentOptions;
            string? listname = listComboBox.SelectedItem.ToString();
            if (listname == null) return currentOptions;
            currentOptions.CurrentList = listname;
            return currentOptions;
        }
    }
}
