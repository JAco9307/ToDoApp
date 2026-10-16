using Todo.view.Forms;

namespace Todo.view.ViewObjects
{
    public partial class TodoViewTag : UserControl
    {
        public event EventHandler? Delete;
        public TodoViewTag(string title, Color color)
        {
            InitializeComponent();
            SetTitle(title);
            SetColor(color);
        }
        private void SetTitle(string title)
        {
            ViewTagText.Text = title;
        }
        private void SetColor(Color color)
        {
            this.BackColor = color;
        }

        public (string, Color) getTag()
        {
            return (ViewTagText.Text, this.BackColor);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure to delete this tag?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult.ToString() == "No")
                return;

            Delete?.Invoke(this, new EventArgs());
            Parent?.Controls.Remove(this);
        }
        private void UpdateTag()
        {
            EditTagForm editTagForm = new EditTagForm(this);
            DialogResult result = editTagForm.ShowDialog();
            if (result.ToString() != "OK")
                return;

            SetColor(editTagForm.TagColor);
            SetTitle(editTagForm.TagTitle);

            Parent?.Refresh();
        }

        private void TodoViewTag_MouseClick(object sender, MouseEventArgs e)
        {
            if (Delete is not null)
                return;

            UpdateTag();
        }

        private void ViewTagText_Click(object sender, EventArgs e)
        {
            if (Delete is not null)
                return;

            UpdateTag();
        }
    }
}
