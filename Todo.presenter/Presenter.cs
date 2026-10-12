using System.Windows.Forms;
using Todo.view;
using Todo.view.Interfaces;
using Todo.model.Interfaces;
using Todo.model.Entities;
using Todo.view.Entities;
using System.Drawing;

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
            _currentListId = 1;
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
            List<string> TodoTitles = TodoList.Select(todoItem => todoItem.Title).ToList();
            List<TodoViewItem> todoViewItems = _view.UpdateActiveViewList(TodoTitles);

            foreach(TodoViewItem item in todoViewItems) {
                item.Delete += delegate { DeleteTodo(TodoList[item.id]);  };
                item.TodoLabel.Click += delegate { EditTodo(TodoList[item.id]); };
            }
        }

        /// <summary>
        /// Opens the dialog for creating a new todo and sets up the todo item afterwards
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
        /// Opens the dialog for editing a todo
        /// </summary>
        /// <param name="todoItem">The todoViewItem to edit.</param>
        private void EditTodo(TodoItem todoItem)
        {
            List<TodoTag> allTags = _service.GetAllTags();
            ContextData contextData = new ContextData(todoItem.Title, todoItem.Tags.Select(tag => (tag.Title, tag.Color)).ToList(), allTags.Select(tag => (tag.Title, tag.Color)).ToList());
            EditTodoForm createTodoForm = new EditTodoForm(contextData);
            DialogResult result = createTodoForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                todoItem.SetTodoTitle(createTodoForm.Titlestr);

                List<TodoTag> newTags = allTags.Where(tag => HasMatchingTitle(createTodoForm, tag)).ToList();
                todoItem.setTags(newTags);

                _service.UpdateTodoItem(todoItem);
                UpdateView();
            }
        }

        private static bool HasMatchingTitle(EditTodoForm createTodoForm, TodoTag tag)
        {
            return createTodoForm.CurrentTags.Any(newTag => newTag.Item1 == tag.Title);
        }



        /// <summary>
        /// Deletes a todoItem .
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        public void DeleteTodo(TodoItem todoItem)
        {
            _service.Delete(_currentListId, todoItem);
            UpdateView();
        }
    }
}
