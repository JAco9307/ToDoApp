using System.Drawing;
using System.Windows.Forms;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Repositories;
using Todo.model.Services;
using Todo.view.Entities;
using Todo.view.Interfaces;
using Todo.view.ViewObjects;

namespace Todo.presenter
{
    public class Presenter
    {
        private readonly ITodoView _view;
        private readonly ITodoService _todoService;
        private readonly IListService _listService;
        private readonly ITagService _tagService;
        private int _currentListId;
        public StatusList? StatusOptions;
        public Presenter(ITodoView view, ITodoService todoService, IListService listService, ITagService tagService)
        {
            _view = view;
            _todoService = todoService;
            _listService = listService;
            _tagService = tagService;
            _currentListId = 1;
        }
        public Presenter(ITodoView view)
        {
            _view = view;
            ITodoRepository todoRepository = new TodoRepository();
            _todoService = new TodoService(todoRepository);
            _listService = new ListService(todoRepository);
            _tagService = new TagService(todoRepository);
            _currentListId = 1;
        }


        /// <summary>
        /// Starts up the view and binds relevant controls.
        /// </summary>
        public void StartUp()
        {
            StatusOptions = _todoService.GetStatusOptions();
            List<Control> controls = _view.StartUp();
            EventHandlerSetup(controls);
            UpdateLists();
            UpdateView();
        }


        /// <summary>
        /// Perform the event handler setup.
        /// </summary>
        /// <param name="controls">List of controls that require binding.</param>
        private void EventHandlerSetup(List<Control> controls)
        {
            controls[0].Click += delegate { CreateTodo(); };
            controls[1].Click += delegate { UpdateOptions(); };
            controls[2].TextChanged += delegate { UpdateSelectedList(controls[2].Text); };
            ComboBox sortBox = (ComboBox)controls[3];
            sortBox.SelectedIndexChanged += delegate { UpdateView(); };
            CheckBox sortOrderCheckBox = (CheckBox)controls[4];
            sortOrderCheckBox.CheckStateChanged += delegate { UpdateView(); };
        }

        /// <summary>
        /// Updates the view item list and binds the delete and edit buttons.
        /// </summary>
        public void UpdateView()
        {
            if (StatusOptions == null) throw new NullReferenceException();
            IReadOnlyList<TodoItem> TodoList = _listService.Get(_currentListId).Items;
            List<TodoData> todoDatas = new List<TodoData>();
            foreach (TodoItem todoItem in TodoList)
            {
                todoDatas.Add(ItemToData(todoItem));
            }
            List<TodoViewItem> todoViewItems = _view.UpdateActiveViewList(todoDatas);

            foreach (TodoViewItem item in todoViewItems)
            {
                item.TodoLabel.Click += delegate { EditTodo(TodoList[item.id], item.id); };
                item.CycleStatus.Click += delegate { CycleStatus(TodoList[item.id], item); };
            }
        }


        /// <summary>
        /// Opens the dialog for creating a new todo and sets up the <see cref="TodoItem"/> afterwards
        /// </summary>
        public void CreateTodo()
        {
            TodoItem? newTodo = HandleEditPopUp(null);
            if (newTodo == null)
                return;
            _todoService.Add(newTodo);
            UpdateView();
        }

        /// <summary>
        /// Opens the dialog for editing a todo
        /// </summary>
        /// <param name="todoItem">The todoViewItem to edit.</param>
        private void EditTodo(TodoItem todoItem, int ViewItemId)
        {
            if (StatusOptions == null) throw new NullReferenceException();
            TodoItem? newTodo = HandleEditPopUp(todoItem);
            if (newTodo == null)
                return;
            _todoService.UpdateDb();
            UpdateView();
        }

        /// <summary>
        /// Handles the edit pop up.
        /// </summary>
        /// <param name="todoItem">The todo item´being edited. null if making new todo item</param>
        /// <returns>The todo item result.</returns>
        private TodoItem? HandleEditPopUp(TodoItem? todoItem)
        {
            bool IsNew = (todoItem == null);
            if (IsNew)
            {
                todoItem = new TodoItem("") { ListId = _currentListId };
            }

            if (StatusOptions == null) throw new NullReferenceException();
            if (todoItem == null) throw new NullReferenceException();

            List<TodoTag> allTags = _tagService.GetAll();

            TodoData todoData = ItemToData(todoItem);

            ContextData context = GetContext();
            context.AllTags = allTags.Select(tag => (tag.Title, tag.Color)).ToList();

            TodoData result = _view.ShowEditTodoDialog(context, todoData, IsNew);

            if (result.ToBeDeleted && IsNew)
                return null;
            if (result.ToBeDeleted)
            {
                DeleteTodo(todoItem);
                UpdateView();
                return null;
            }

            if (result.Title == null)
                return todoItem;

            todoItem.ListId = _listService.Get(result.ListTitle).Id;
            List<TodoTag> newTags = allTags.Where(tag => HasMatchingTitle(result, tag)).ToList();

            todoItem.SetTodoTitle(result.Title);
            todoItem.SetTodoStatus(result.Status);
            todoItem.setTags(newTags);
            todoItem.SetDescription(result.Description);

            _todoService.UpdateDb();
            UpdateView();

            return todoItem;
        }

        private static bool HasMatchingTitle(TodoData todoData, TodoTag tag)
        {
            return todoData.CurrentTags.Any(newTag => newTag.Item1 == tag.Title);
        }


        /// <summary>
        /// Deletes a <see cref="TodoItem"/> .
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        public void DeleteTodo(TodoItem todoItem)
        {
            _todoService.Delete(todoItem);
            UpdateView();
        }

        /// <summary>
        /// Updates the Status of a <see cref="TodoItem"/>.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <param name="Status">The Status.</param>
        public void UpdateStatus(TodoItem todoItem, string Status)
        {
            todoItem.SetTodoStatus(Status);
        }

        /// <summary>
        /// Opens the options menu and updates the options.
        /// </summary>
        public void UpdateOptions()
        {
            // Set up and open options
            if (StatusOptions == null) return;
            List<string> currentListNames = _listService.GetNames();
            List<TodoTag> allTags = _tagService.GetAll();
            List<(string title, Color color)> tags = allTags.Select(tag => (tag.Title, tag.Color)).ToList();

            TodoOptions newOptions = _view.ShowOptionsMenu(new TodoOptions
            {
                Status = StatusOptions.options,
                ListNames = currentListNames,
                Tags = tags
            });

            // Handle updating options
            StatusOptions.options = newOptions.Status;
            newOptions.ListNameChanges ??= [];

            UpdateListNames(currentListNames, newOptions);
            UpdateTags(allTags, newOptions);

            _todoService.UpdateDb();
            UpdateLists();

            void UpdateListNames(List<string> currentListNames, TodoOptions newOptions)
            {
                var renamedFrom = newOptions.ListNameChanges.Keys.ToHashSet();
                var renamedTo = newOptions.ListNameChanges.Values.ToHashSet();

                foreach (var (OldName, NewName) in newOptions.ListNameChanges)
                    _listService.Rename(OldName, NewName);

                foreach (var title in newOptions.ListNames.Except(currentListNames))
                    if (!renamedTo.Contains(title))
                        _listService.Add(title);

                foreach (var title in currentListNames.Except(newOptions.ListNames))
                    if (!renamedFrom.Contains(title))
                        _listService.Delete(title);
            }

            void UpdateTags(List<TodoTag> allTags, TodoOptions newOptions)
            {
                List<TodoTag> addedTags = new List<TodoTag>();
                List<TodoTag> removedTags = new List<TodoTag>();
                var remainingTags = newOptions.Tags.ToList();

                foreach (var tag in allTags)
                {
                    var matchingTag = remainingTags.FirstOrDefault(option => option.Item1 == tag.Title);
                    if (matchingTag != default)
                        remainingTags.Remove(matchingTag);
                    else
                        removedTags.Add(tag);
                }
                addedTags.AddRange(remainingTags.Select(tag => new TodoTag(tag.Item1, tag.Item2)));

                _tagService.AddOptions(addedTags);
                _tagService.RemoveOptions(removedTags);
            }
        }

        /// <summary>
        /// Cycles the Status on the todo item.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <param name="sender">The sender.</param>
        public void CycleStatus(TodoItem todoItem, TodoViewItem sender)
        {
            if (StatusOptions == null) return;

            var opt = StatusOptions.options;
            int index = opt.FindIndex(status => status == todoItem.Status);

            todoItem.SetTodoStatus(opt[(index + 1) % opt.Count]);
            sender.Status = todoItem.Status;

            _todoService.UpdateDb();
        }

        public void UpdateLists()
        {
            var ListTitles = _listService.GetNames();
            if (_currentListId - 1 < ListTitles.Count)
                _view.UpdateComboboxLists(ListTitles, ListTitles[_currentListId - 1]);
            else
                _view.UpdateComboboxLists(ListTitles, ListTitles[0]);

        }

        private void UpdateSelectedList(string Title)
        {
            var SelectedList = _listService.Get(Title);
            _currentListId = SelectedList.Id;
            UpdateView();
        }

        /// <summary>
        /// Converts <see cref="TodoItem"> to <see cref="TodoData"/>.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <returns>The todo data.</returns>
        public TodoData ItemToData(TodoItem todoItem)
        {
            return new TodoData
            {
                Title = todoItem.Title,
                Status = todoItem.Status,
                ListTitle = _listService.Get(todoItem.ListId).Title,
                CurrentTags = todoItem.Tags.Select(tag => (tag.Title, tag.Color)).ToList(),
                Description = todoItem.Description,

            };
        }

        /// <summary>
        /// Gets the current context information.
        /// </summary>
        /// <returns>The context data result.</returns>
        public ContextData GetContext()
        {
            if (StatusOptions == null) throw new NullReferenceException();
            return new ContextData
            {
                StatusOptions = StatusOptions.options,
                ListNames = _listService.GetNames()
            };
        }
    }
}
