using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Todo.view.Entities;
using Todo.view.Interfaces;
using Todo.view.EditItems;

namespace Todo.view
{
    public partial class EditTodoForm : Form
    {
        public TodoData todoData;
        private List<ITodoPropertyEdit> EditItems;
        /// <summary>
        /// Initializes a new instance of the <see cref="EditTodoForm"/> class.
        /// </summary>
        /// <param name="_context">The current context.</param>
        /// <param name="_todoData">The current todo data.</param>
        public EditTodoForm(ContextData _context, TodoData _todoData)
        {
            InitializeComponent();
            EditItems = new List<ITodoPropertyEdit>
            {
                new TitleEdit(_todoData),
                new StatusEdit(_todoData,_context)
            };
            foreach (ITodoPropertyEdit EditItem in EditItems)
            {
                flowLayoutPanel.Controls.Add((Control)EditItem);
            }


            TodoTagsComboBox.Items.AddRange(AllTags.Select(x => x.Item1).ToArray());

        }
        public void cancelClick(object sender, EventArgs e)
        {
            Close();
        }

        public void saveClick(object sender, EventArgs e)
        {
            foreach (ITodoPropertyEdit EditItem in EditItems)
            {
                todoData = EditItem.UpdateData(todoData);
            }
            Close();
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
