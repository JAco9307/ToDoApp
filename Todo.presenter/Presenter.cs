using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Migrations;
using Todo.view;
using Todo.view.Interfaces;

namespace Todo.presenter
{
    public class Presenter
    {
        private readonly ITodoView _view;
        private readonly ITodoService _service;
        private int _currentListId;
        private StatusList? statusOptions;
        public Presenter(ITodoView view, ITodoService service)
        {
            _view = view;
            _service = service;
            _currentListId = 1;
        }


        /// <summary>
        /// Starts up the view and binds relevant controls.
        /// </summary>
        public void StartUp()
        {
            List<Control> controls = _view.StartUp();
            EventHandlerSetup(controls);
            statusOptions = _service.GetStatusOptions();
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
            List<string> TodoTitles = TodoList.Select(todoItem => todoItem.Title).ToList();
            List<TodoViewItem> todoViewItems = _view.UpdateActiveViewList(TodoTitles);

            foreach(TodoViewItem item in todoViewItems) {
            
                item.Delete += delegate { DeleteTodo(TodoList[item.id]);  };
                item.editButton.Click += delegate { EditTodo(TodoList[item.id]); };
                item.CycleStatus.Click += delegate { CycleStatus(TodoList[item.id], item); };
            }
        }

        /// <summary>
        /// Opens the dialog for creating a new todo and sets up the <see cref="TodoItem"/> afterwards
        /// </summary>
        public void CreateTodo()
        {
            var result = _view.ShowEditTodoDialog();
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
        /// <param name="todoItem">The todoViewItem to edit.</param>
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
        /// Deletes a <see cref="TodoItem"/> .
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        public void DeleteTodo(TodoItem todoItem)
        {
            _service.Delete(_currentListId, todoItem);
            UpdateView();
        }

        /// <summary>
        /// Updates the status of a <see cref="TodoItem"/>.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <param name="status">The status.</param>
        public void UpdateStatus(TodoItem todoItem, string status)
        {
            todoItem.SetTodoStatus(status);
        }

        public void CycleStatus(TodoItem todoItem, TodoViewItem sender)
        {
            if (statusOptions == null) return;
            int index = statusOptions.options.FindIndex(status => status == todoItem.Status);
            todoItem.SetTodoStatus(statusOptions.options[(index+1) % statusOptions.options.Count]);
            sender.Status = todoItem.Status;
        }
    }
}
