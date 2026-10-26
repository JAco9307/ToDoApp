using System.Data;
using Todo.DTOs;
using Todo.view.Dialogs;
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
            currentOptions.ListNameChanges ??= [];
            foreach (var nameChange in ListNameChanges)
                currentOptions.ListNameChanges.Add(nameChange.Key, nameChange.Value);

            return currentOptions;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null) return;
            var result = MessageBox.Show(
                "Are you sure you want to delete " + listBox.SelectedItem.ToString() + "?" +
                "\nThis will also delete all todos on the list." +
                "\nThis action becomes permanent when saving",
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

        private void renameButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null) return;
            var inputDialog = new TextInputDialog("List name:", listBox.SelectedItem.ToString() ?? "ERROR");
            var result = inputDialog.ShowDialog();

            if (result != DialogResult.OK) return;
            if (listBox.Items.Contains(inputDialog.text))
            {
                MessageBox.Show(
                "A list with this name already exists",
                "Cannot complete action",
                MessageBoxButtons.OK);
                return;
            }

            ListNameChanges.Add(listBox.SelectedItem.ToString() ?? "ERROR", inputDialog.text);
            listBox.Items.Remove(listBox.SelectedItem);
            listBox.Items.Add(inputDialog.text);

        }
    }
}
