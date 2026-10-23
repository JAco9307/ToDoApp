namespace Todo.view.Dialogs
{
    public partial class TextInputDialog : Form
    {
        public string text => textBox.Text;
        public TextInputDialog(string header, string defaultText = "")
        {
            InitializeComponent();
            headerLabel.Text = header;
            textBox.Text = defaultText;
            textBox.Select();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
