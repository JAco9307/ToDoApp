using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Todo.view.ViewObjects;

namespace Todo.view.Forms
{
    public partial class EditTagForm : Form
    {
        public string TagTitle;
        public Color TagColor;

        public EditTagForm(TodoViewTag viewTag)
        {
            InitializeComponent();
            (string title, Color color) tag = viewTag.getTag();
            TagTitle = tag.title;
            TagColor = tag.color;
            panel1.BackColor = TagColor;
            textBox1.Text = TagTitle;
        }

        private void PickColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            var result = colorDialog.ShowDialog();
            panel1.BackColor = colorDialog.Color;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            TagColor = panel1.BackColor;
            TagTitle = textBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
