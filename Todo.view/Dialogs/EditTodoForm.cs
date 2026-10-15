using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Todo.view.EditItems;
using Todo.view.Entities;
using Todo.view.Interfaces;
using Todo.view.OptionsItems;

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
        public EditTodoForm(ContextData _context, TodoData _todoData, bool IsNew = false)
        {
            InitializeComponent();
            EditItems = new List<ITodoPropertyEdit>
            {
                new TitleEdit(_todoData),
                new StatusEdit(_todoData,_context),
                new ListIdEdit(_context, _todoData)
            };
            foreach (ITodoPropertyEdit EditItem in EditItems)
            {
                flowLayoutPanel.Controls.Add((Control)EditItem);
            }
            if (IsNew)
            {
                tableLayoutPanel.ColumnCount = 2;
            }
        }

        public void saveClick(object sender, EventArgs e)
        {
            foreach (ITodoPropertyEdit EditItem in EditItems)
            {
                todoData = EditItem.UpdateData(todoData);
            }
            Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                todoData.ToBeDeleted = true;
                Close();
            }
        }
    }
}
