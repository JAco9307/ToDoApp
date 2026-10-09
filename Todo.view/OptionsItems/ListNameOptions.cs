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
    public partial class ListNameOptions : UserControl, IOption
    {
        public ListNameOptions(TodoOptions currentOptions)
        {
            InitializeComponent();
            listBox.Items.AddRange(currentOptions.ListNames.ToArray());
        }

        public TodoOptions Save(TodoOptions currentOptions)
        {
            currentOptions.ListNames = listBox.Items.Cast<string>().ToList();
            return currentOptions;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null) return;
            var result = MessageBox.Show(
                "Are you sure you want to delete " + listBox.SelectedItem.ToString(), 
                "Delete list", 
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                listBox.Items.Remove(listBox.SelectedItem);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var result = new TextInputDialog("List name:");
            if (result.ShowDialog() == DialogResult.OK)
            {
                listBox.Items.Add(result.text);
            }
        }
    }
}
