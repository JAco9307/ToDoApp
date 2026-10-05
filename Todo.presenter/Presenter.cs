using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Todo.view;
using Todo.view.Interfaces;
using Todo.model.Interfaces;
using Todo.model.Entities;

namespace Todo.presenter
{
    public class Presenter
    {
        private readonly ITodoView _view;
        private readonly ITodoService _service;
        private int _currentListId;
        public Presenter(ITodoView view, ITodoService service)
        {
            _view = view;
            _service = service;
            _currentListId = 0;
        }


        /// <summary>
        /// Starts up the view and binds relevant controls.
        /// </summary>
        public void StartUp()
        {
            List<Control> controls = _view.StartUp();
            EventHandlerSetup(controls);
            UpdateView();

        }


        /// <summary>
        /// Perform the event handler setup.
        /// </summary>
        /// <param name="controls">List of controls that require binding.</param>
        private void EventHandlerSetup(List<Control> controls)
        {
            controls[0].Click += delegate { CreateTodo(); };
        }

        /// <summary>
        /// Updates the view item list and binds the delete and edit buttons.
        /// </summary>
        public void UpdateView()
        {
            IReadOnlyList<TodoItem> TodoList = _service.GetTodoList(_currentListId).Items;
            List<string> TodoTitles = TodoList.Select(z => z.Title).ToList();
            List<TodoViewItem> todoViewItems = _view.UpdateActiveViewList(TodoTitles);

            for (int i = 0; i < todoViewItems.Count; i++)
            {
                todoViewItems[i].deleteButton.Click += delegate { DeleteTodo(TodoList[i]);  };
                todoViewItems[i].editButton.Click   += delegate { EditTodo(TodoList[i]);    };
            }
        }

        /// <summary>
        /// Opens the dialog for creating a new todo and sets up the todo item afterwards
        /// </summary>
        public void CreateTodo()
        {
            var result = _view.GetPopupResult();
            if (result.dialogResult == DialogResult.OK)
            {
                TodoItem newTodo = new(result.title);
                _service.Add(_currentListId, newTodo);
                UpdateView();
            }
        }

        /// <summary>
        /// Opens the dialog for editing a todo and resolves it
        /// edit buttons are disabled until post mvp so this cant be called yet
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


        /// <summary>
        /// Deletes a todoItem .
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        public void DeleteTodo(TodoItem todoItem)
        {
            _service.Delete(_currentListId, todoItem);
        }
    }
}
