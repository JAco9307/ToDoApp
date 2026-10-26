using System.Data;
using Todo.DTOs;
using Todo.view.Dialogs;
using Todo.view.Interfaces;

namespace Todo.view.OptionsItems
{
    public partial class StatusOptions : UserControl, IOption
    {
        public StatusOptions(TodoOptions currentOptions)
        {
            InitializeComponent();
            statusBox.Items.AddRange(currentOptions.Status.ToArray());
        }

        public TodoOptions Save(TodoOptions currentOptions)
        {
            if (statusBox.Items.Count == 0) return currentOptions;
            try
            {
                List<string> result = statusBox.Items.Cast<string>().ToList();
                currentOptions.Status = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot parse Status options\n" + ex.ToString(), "Error", MessageBoxButtons.OK);
            }
            return currentOptions;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var inputDialog = new TextInputDialog("List name:");
            var result = inputDialog.ShowDialog();

            if (statusBox.Items.Contains(inputDialog.text))
            {
                MessageBox.Show(
                "A status with this name already exists",
                "Cannot complete action",
                MessageBoxButtons.OK);
                return;
            }

            if (result == DialogResult.OK)
            {
                statusBox.Items.Add(inputDialog.text);
            }
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            if (statusBox.SelectedItem == null) return;
            var inputDialog = new TextInputDialog("Status name:", statusBox.SelectedItem.ToString() ?? "ERROR");
            var result = inputDialog.ShowDialog();

            if (result != DialogResult.OK) return;
            if (statusBox.Items.Contains(inputDialog.text))
            {
                MessageBox.Show(
                "A status with this name already exists",
                "Cannot complete action",
                MessageBoxButtons.OK);
                return;
            }

            statusBox.Items.Remove(statusBox.SelectedItem);
            statusBox.Items.Add(inputDialog.text);

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (statusBox.SelectedItem == null) return;
            statusBox.Items.Remove(statusBox.SelectedItem);
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(false);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(true);
        }

        private void MoveSelectedItem(bool direction)
        {
            if (statusBox.SelectedItem == null) return;

            int index = statusBox.SelectedIndex;
            int newIndex = index + (direction ? 1 : -1);

            if (newIndex < 0 || newIndex >= statusBox.Items.Count)
                return;

            (statusBox.Items[index], statusBox.Items[newIndex]) =
                (statusBox.Items[newIndex], statusBox.Items[index]);

            statusBox.SelectedIndex = newIndex;
        }
    }
}
