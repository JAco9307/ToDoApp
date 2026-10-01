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
        /// <param name="controls">List of controls that require binding.</param>
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

        /// <summary>
        /// Opens the dialog for creating a new todo and resolves it
        /// </summary>
        public void CreateTodo()
        {
            var CreateTodoForm = new EditTodoForm();
            var result = CreateTodoForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // update the item through ITodoServices

                // the following is temp code
                Console.WriteLine(CreateTodoForm.Titlestr);
                List<TodoViewItem> todoViewItems = _view.UpdateActiveViewList(null);
                todoViewItems[0].deleteButton.Click += delegate { DeleteTodo("Delete me"); };
                todoViewItems[0].editButton.Click += delegate { EditTodo(0); };
            }
        }

        /// <summary>
        /// Opens the dialog for editing a todo and resolves it
        /// </summary>
        /// <param name="todoViewItemIndex">The index (!= ID) of the todoViewItem to edit.</param>
        private void EditTodo(int todoViewItemIndex)
        {
            var CreateTodoForm = new EditTodoForm();
            var result = CreateTodoForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Console.WriteLine(CreateTodoForm.Titlestr);
                // update the item through ITodoServices
            }
        }

        public void DeleteTodo(string a = "hi")
        {
            Console.WriteLine(a);
        }

    }
}
