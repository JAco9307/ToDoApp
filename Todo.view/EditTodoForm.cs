using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Todo.view.Entities;

namespace Todo.view
{
    public partial class EditTodoForm : Form
    {
        public string Titlestr;
        public List<(string, Color)> CurrentTags;
        public List<(string, Color)> AllTags;
        public EditTodoForm(ContextData todoParameters)
        {
            InitializeComponent();
            Titlestr = todoParameters.Title;
            CurrentTags = todoParameters.CurrentTags;
            AllTags = todoParameters.AllTags;

            titleTextBox.Text = Titlestr;
            TodoTagsComboBox.Items.AddRange(AllTags.Select(x => x.Item1).ToArray());

        }
        public void cancelClick(object sender, EventArgs e) 
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public void saveClick(object sender, EventArgs e) 
        {
            Titlestr = titleTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void TagsComboBoxSelectionChanged(object sender, EventArgs e)
        {
            if(CurrentTags == null)
                throw new NullReferenceException();

            if (TodoTagsComboBox.SelectedItem is not string)
                return;

            CurrentTags.Add(AllTags.FirstOrDefault(tag => tag.Item1 == (string)TodoTagsComboBox.SelectedItem));
            TodoTagsComboBox.Items.Remove(TodoTagsComboBox.SelectedItem.ToString());


        }
    }
}
