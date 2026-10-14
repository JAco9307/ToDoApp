using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Todo.view.Entities;

namespace Todo.view
{
    public partial class EditTodoForm : Form
    {
        public string? Titlestr;
        public List<(string, Color)> CurrentTags;
        public List<(string, Color)> AllTags;
        public string Status;
        public EditTodoForm(ContextData context, TodoData todoData)
        {
            InitializeComponent();
            Titlestr = todoData.Title;
            CurrentTags = todoData.CurrentTags;
            AllTags = context.AllTags;

            titleTextBox.Text = Titlestr;
            titleTextBox.Select();
            statusComboBox.Items.AddRange(context.StatusOptions.ToArray());
            if (todoData.Status == null)
            {
                statusComboBox.SelectedItem = context.StatusOptions[0];
                Status = context.StatusOptions[0];
            }
            else
            {
                statusComboBox.SelectedItem = todoData.Status;
                Status = todoData.Status;
            }


            TodoTagsComboBox.Items.AddRange(AllTags.Select(x => x.Item1).ToArray());

        }
        public void cancelClick(object sender, EventArgs e)
        {
            Titlestr = null;
            this.Close();
        }
        public void saveClick(object sender, EventArgs e)
        {
            if (statusComboBox.SelectedItem == null) return;
            if (titleTextBox.Text == "") return;
            Titlestr = titleTextBox.Text;
            Status = statusComboBox.Text;
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
