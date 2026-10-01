using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Todo.view;
using Todo.view.Interfaces;
using Todo.model.Interfaces;
using Todo.model;

namespace Todo.presenter
{
    public class Presenter
    {
        private ITodoView _view;
        private ITodoService _service;
        private int _currentListId;
        public Presenter(ITodoView view, ITodoService service)
        {
            _view = view;
            _service = service;
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
            IReadOnlyList<TodoItem> TodoList = _service.GetTodoList(_currentListId);
            List<string> TodoTitles = TodoList.Select(z => z.Title).ToList();
            List<TodoViewItem> todoViewItems = _view.UpdateActiveViewList(TodoTitles);

            for (int i = 0; i < todoViewItems.Count; i++)
            {
                todoViewItems[i].deleteButton.Click += delegate { DeleteTodo(TodoList[i]);  };
                todoViewItems[i].editButton.Click   += delegate { EditTodo(TodoList[i]);    };
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
                TodoItem newTodo = new(CreateTodoForm.Titlestr);
                _service.Add(_currentListId, newTodo); 

                // the following is temp code
                Console.WriteLine(CreateTodoForm.Titlestr);

                List<string> todoTitles = new List<string>();
                todoTitles.Add(CreateTodoForm.Titlestr);
                List<TodoViewItem> todoViewItems = _view.UpdateActiveViewList(todoTitles);

                todoViewItems[0].deleteButton.Click += delegate { DeleteTodo(newTodo);  };
                todoViewItems[0].editButton.Click += delegate   { EditTodo(newTodo);    };
            }
        }

        /// <summary>
        /// Opens the dialog for editing a todo and resolves it
        /// </summary>
        /// <param name="todoViewItemIndex">The index (!= ID) of the todoViewItem to edit.</param>
        private void EditTodo(TodoItem todoItem)
        {
            var CreateTodoForm = new EditTodoForm();
            var result = CreateTodoForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Console.WriteLine(CreateTodoForm.Titlestr);
                // update the item through ITodoServices
            }
        }


        public void DeleteTodo(TodoItem todoItem)
        {
            Console.WriteLine(todoItem.Title);
            _service.Delete(_currentListId, todoItem);
        }

    }
}
