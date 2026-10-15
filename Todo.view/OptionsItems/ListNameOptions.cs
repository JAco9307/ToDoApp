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
        private Dictionary<string, string> ListNameChanges = new();
        public ListNameOptions(TodoOptions currentOptions)
        {
            InitializeComponent();
            listBox.Items.AddRange(currentOptions.ListNames.ToArray());
        }

        public TodoOptions Save(TodoOptions currentOptions)
        {
            currentOptions.ListNames = listBox.Items.Cast<string>().ToList();
            if (currentOptions.ListNameChanges == null) { currentOptions.ListNameChanges = new(); }
            foreach (var nameChange in ListNameChanges) 
                currentOptions.ListNameChanges.Add(nameChange.Key, nameChange.Value); 

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
            var inputDialog = new TextInputDialog("List name:");
            var result = inputDialog.ShowDialog();
            if (listBox.Items.Cast<string>().ToList().Contains(inputDialog.text))
            {
                MessageBox.Show(
                "A list with this name already exists",
                "Cannot complete action",
                MessageBoxButtons.OK);
                return;
            }
            if (result == DialogResult.OK)
            {
                listBox.Items.Add(inputDialog.text);
            }
        }

        private void nameButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null) return; 
            var inputDialog = new TextInputDialog("List name:");
            var result = inputDialog.ShowDialog();
            if (listBox.Items.Cast<string>().ToList().Contains(inputDialog.text))
            {
                MessageBox.Show(
                "A list with this name already exists",
                "Cannot complete action",
                MessageBoxButtons.OK);
                return;
            }
            if (result == DialogResult.OK)
            {
                ListNameChanges.Add(listBox.SelectedItem.ToString(), inputDialog.text);
                listBox.Items.Remove(listBox.SelectedItem);
                listBox.Items.Add(inputDialog.text);
            }
        }
    }
}
