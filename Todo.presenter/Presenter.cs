using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
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
        private readonly IStatusService _statusService;
        private int _currentListId;
        public Presenter(ITodoView view, ITodoService todoService, IListService listService, ITagService tagService, IStatusService statusService)
        {
            _view = view;
            _todoService = todoService;
            _listService = listService;
            _tagService = tagService;
            _statusService = statusService;
            _currentListId = 1;
        }
        public Presenter(ITodoView view)
        {
            _view = view;
            ITodoRepository todoRepository = new TodoRepository();
            _todoService = new TodoService(todoRepository);
            _listService = new ListService(todoRepository);
            _tagService = new TagService(todoRepository);
            _statusService = new StatusService(todoRepository);
            _currentListId = 1;
        }


        /// <summary>
        /// Starts up the view and binds relevant controls.
        /// </summary>
        public void StartUp()
        {
            //_statusOptions = _todoService.GetStatusOptions();
            List<Control> controls = _view.StartUp();
            EventHandlerSetup(controls);
            UpdateView();
            UpdateLists();
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
            List<Status> statusOptions = _statusService.GetStatusOptions();
            if (statusOptions == null) throw new NullReferenceException();
            if (IsNew)
            {
                todoItem = new TodoItem("", statusOptions[0]) { ListId = _currentListId };
            }
            
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

            if (result.Title == "" || result.Title == null)
                return null;

            todoItem.ListId = _listService.Get(result.ListTitle).Id;
            List<TodoTag> newTags = allTags.Where(tag => HasMatchingTitle(result, tag)).ToList();

            Status todoStatus = statusOptions.Find(status => status.Id == result.Status.Id);
            
            todoItem.SetTodoTitle(result.Title);
            todoItem.SetTodoStatus(todoStatus);
            todoItem.SetTags(newTags);
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
            todoItem.SetTodoStatus(new Status(Status));
        }

        /// <summary>
        /// Opens the options menu and updates the options.
        /// </summary>
        public void UpdateOptions()
        {
            // Set up and open options
            List<Status> statusOptions = _statusService.GetStatusOptions();
            if (statusOptions == null) return;
            List<string> currentListNames = _listService.GetNames();
            List<TodoTag> allTags = _tagService.GetAll();
            List<(string title, Color color)> tags = allTags.Select(tag => (tag.Title, tag.Color)).ToList();

            List<StatusData> statusDatas = new List<StatusData>();
            foreach (var status in statusOptions)
            {
                statusDatas.Add(new StatusData(status.Id, status.Title, status.Order));
            }
            
            TodoOptions newOptions = _view.ShowOptionsMenu(new TodoOptions
            {
                Status = statusDatas,
                ListNames = currentListNames,
                Tags = tags
            });

            // Handle updating options
            newOptions.ListNameChanges ??= [];
            UpdateStatuses(statusOptions, newOptions);
            UpdateListNames(currentListNames, newOptions);
            UpdateTags(allTags, newOptions);
            Import(newOptions);
            Export(newOptions);

            _todoService.UpdateDb();
            UpdateLists();
        }

        private void Export(TodoOptions newOptions)
        {
            if (!newOptions.CreateExport)
                return;

            List<TodoList> lists = new List<TodoList>();
            List<string> names = _listService.GetNames();
            foreach (string name in names)
            {
                lists.Add(_listService.Get(name));
            }
            new ImportService(_listService, _tagService, _todoService, _statusService).ExportJson(lists);
            UpdateOptions();
        }

        private void Import(TodoOptions newOptions)
        {
            if (newOptions.ImportFilePath == null)
                return;
            if (newOptions.ImportFilePath == "")
                return;
            bool result = new ImportService(_listService, _tagService, _todoService, _statusService).ImportJson(newOptions.ImportFilePath);
            if (!result)
                MessageBox.Show("Import of lists failed, ensure the correct json was chosen.", "Import failed", MessageBoxButtons.OK);
        }

        private void UpdateListNames(List<string> currentListNames, TodoOptions newOptions)
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

        private void UpdateTags(List<TodoTag> allTags, TodoOptions newOptions)
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

            if (addedTags.Count > 0)
                _tagService.AddOptions(addedTags);
            if (removedTags.Count > 0)
                _tagService.RemoveOptions(removedTags);
        }
            
        private void UpdateStatuses(List<Status> statusOptions, TodoOptions todoOptions)
        {
            List<Status> toBeDeleted = new List<Status>();
            foreach (Status statusOption in statusOptions)
            {
                var matchingStatus = todoOptions.Status.FirstOrDefault(status => status.Id == statusOption.Id);
                if (matchingStatus.Id == 0)
                {
                    toBeDeleted.Add(statusOption);
                }
            }
                
            List<Status> addedStatus = new List<Status>();
            foreach (StatusData statusData in todoOptions.Status)
            {
                Status? foundStatus = statusOptions.Find(status => status.Id == statusData.Id);
                if (foundStatus == null)
                {
                    Status itemToAdd = new Status(statusData.Title);
                    addedStatus.Add(itemToAdd);
                    statusOptions.Add(itemToAdd);
                    continue;
                }
                foundStatus.Title = statusData.Title;
                foundStatus.Order = statusData.Order;
            }
                
            _statusService.AddOptions(addedStatus);
            _statusService.DeleteOptions(toBeDeleted);
        }

    /// <summary>
    /// Cycles the Status on the todo item.
    /// </summary>
    /// <param name="todoItem">The todo item.</param>
    /// <param name="sender">The sender.</param>
    public void CycleStatus(TodoItem todoItem, TodoViewItem sender)
    {
        List<Status> statusOptions = _statusService.GetStatusOptions();
        if (statusOptions == null) return;

        statusOptions.Contains(todoItem.Status);
        
        int index = statusOptions.FindIndex(status => status.Title == todoItem.Status.Title);
            
        todoItem.SetTodoStatus(statusOptions[(index + 1) % statusOptions.Count]);
            
        sender.Status = new StatusData(todoItem.Status.Id, todoItem.Status.Title, todoItem.Status.Order);
            
        _todoService.UpdateDb();
    }

    /// <summary>
    /// Updates the lists in the <see cref="ComboBox"/> list selector.
    /// </summary>
    public void UpdateLists()
    {
        var ListTitles = _listService.GetNames();
        if (_currentListId - 1 < ListTitles.Count)
            _view.UpdateComboboxLists(ListTitles, ListTitles[_currentListId - 1]);
        else
            _view.UpdateComboboxLists(ListTitles, ListTitles[0]);

    }

    /// <summary>
    /// Updates the selected list and updates view after to reflect changes.
    /// </summary>
    /// <param name="Title">The title.</param>
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
        Status status;
        if (todoItem.Status == null)
        {
            status = _statusService.GetStatusOptions()[0];
        }
        else
        {
            status = _statusService.GetStatusOptions().Find(status => status.Id == todoItem.Status.Id);
        }
            
        StatusData statusData = new StatusData(status.Id, status.Title, status.Order);
        return new TodoData
        {
            Title = todoItem.Title,
            Status = statusData,
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
        List<Status> _statusOptions = _statusService.GetStatusOptions();
        if (_statusOptions == null) throw new NullReferenceException();
        List<StatusData> statusDatas = new List<StatusData>();
        foreach (Status status in _statusOptions)
        {
            statusDatas.Add(new StatusData(status.Id,status.Title,status.Order));
        }
        return new ContextData
        {
            StatusOptions = statusDatas,
            ListNames = _listService.GetNames()
        };
    }
}
}