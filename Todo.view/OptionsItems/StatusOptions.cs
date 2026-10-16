using System.Data;
using Todo.view.Dialogs;
using Todo.view.Entities;
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
            if (statusBox.SelectedIndex >= statusBox.Items.Count - 1 && direction) return;
            if (statusBox.SelectedIndex == 0 && !direction) return;

            int dir = direction ? 1 : -1;

            int selectIndex = statusBox.SelectedIndex;
            (statusBox.Items[selectIndex + dir], statusBox.Items[selectIndex])
                = (statusBox.Items[selectIndex], statusBox.Items[selectIndex + dir]);
            statusBox.SelectedItem = statusBox.Items[selectIndex + dir];
        }
    }
}
