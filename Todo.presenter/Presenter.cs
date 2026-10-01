using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Todo.view;
using Todo.view.Interfaces;

namespace Todo.presenter
{
    public class Presenter
    {
        private ITodoView _view;
        private int _currentListId;
        public Presenter(ITodoView view, object? service)
        {
            _view = view;
            _currentListId = 0;
        }

        public void StartUp()
        {
            List<Control> controls = _view.StartUp();
            EventHandlerSetup(controls);

        }

        /// <summary>
        /// Perform the event handler setup.
        /// </summary>
        /// <param name="main">The View object.</param>
        private void EventHandlerSetup(List<Control> controls)
        {
            controls[0].Click += delegate { CreateTodo(); };
        }

        public void UpdateView()
        {
            List<TodoViewItem> deleteButtons = _view.UpdateActiveViewList(null);

            for (int i = 0; i < deleteButtons.Count; i++)
            {
                deleteButtons[i].deleteButton.Click += delegate { DeleteTodo("delete " + i); };
            }
        }

        public void CreateTodo()
        {
            var CreateTodoForm = new EditTodoForm();
            var result = CreateTodoForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // all temp code, should be replaced later
                Console.WriteLine(CreateTodoForm.Titlestr);
                List<TodoViewItem> todoViewItems = _view.UpdateActiveViewList(null);
                todoViewItems[0].deleteButton.Click += delegate { DeleteTodo("Delete me"); };
                todoViewItems[0].editButton.Click += delegate { EditTodo(todoViewItems[0]); };
            }
        }

        private void EditTodo(TodoViewItem todoViewItem)
        {
            var CreateTodoForm = new EditTodoForm();
            var result = CreateTodoForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                todoViewItem.textBox.Text = CreateTodoForm.Titlestr; // should edit the item in database instead
                // update view after
            }
        }

        public void DeleteTodo(string a = "hi")
        {
            Console.WriteLine(a);
        }

    }
}
