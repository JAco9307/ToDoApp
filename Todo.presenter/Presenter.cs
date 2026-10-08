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
            if (statusOptions == null) throw new NullReferenceException();
            IReadOnlyList<TodoItem> TodoList = _service.GetTodoList(_currentListId).Items;
            List<string> TodoTitles = TodoList.Select(todoItem => todoItem.Title).ToList();
            List<string> TodoStatus = TodoList.Select(todoItem => todoItem.Status).ToList();
            List<TodoViewItem> todoViewItems = _view.UpdateActiveViewList(TodoTitles, TodoStatus);

            foreach(TodoViewItem item in todoViewItems) {
                item.Delete += delegate { DeleteTodo(TodoList[item.id]);  };
                item.TodoLabel.Click += delegate { EditTodo(TodoList[item.id]); };
            }
        }

        /// <summary>
        /// Opens the dialog for creating a new todo and sets up the <see cref="TodoItem"/> afterwards
        /// </summary>
        public void CreateTodo()
        {
            if (statusOptions == null) throw new NullReferenceException();
            var result = _view.ShowEditTodoDialog(statusOptions.options);
            if (result.dialogResult == DialogResult.OK)
            {
                TodoItem newTodo = new(result.title);
                newTodo.SetTodoStatus(result.status);
                _service.Add(_currentListId, newTodo);
                UpdateView();
            }
        }
        
        /// <summary>
        /// Opens the dialog for editing a todo
        /// </summary>
        /// <param name="todoItem">The todoViewItem to edit.</param>
        private void EditTodo(TodoItem todoItem)
        {
            if (statusOptions == null) throw new NullReferenceException();
            EditTodoForm createTodoForm = new EditTodoForm(statusOptions.options, todoItem.Title);
            DialogResult result = createTodoForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Console.WriteLine(createTodoForm.Titlestr);
                todoItem.SetTodoTitle(createTodoForm.Titlestr);
                _service.UpdateTodoItem(todoItem);
                UpdateView();
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
            //Edit todo item here
        }
    }
}
