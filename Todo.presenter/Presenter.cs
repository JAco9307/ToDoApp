using System.Drawing;
using System.Windows.Forms;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.view.Entities;
using Todo.view.Interfaces;
using Todo.view.ViewObjects;

namespace Todo.presenter
{
    public class Presenter
    {
        private readonly ITodoView _view;
        private readonly ITodoService _service;
        private int _currentListId;
        public List<Status> StatusOptions;

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
            StatusOptions = _service.GetStatusOptions();
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
            IReadOnlyList<TodoItem> TodoList = _service.GetTodoList(_currentListId).Items;
            List<TodoData> todoDatas = new List<TodoData>();
            foreach (TodoItem todoItem in TodoList)
            {
                todoDatas.Add(ItemToData(todoItem));
            }
            List<TodoViewItem> todoViewItems = _view.UpdateActiveViewList(todoDatas);

            foreach(TodoViewItem item in todoViewItems) {
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
            _service.Add(_currentListId, newTodo);
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
            _service.UpdateDb();
            UpdateView();
        }

        private TodoItem? HandleEditPopUp(TodoItem? todoItem)
        {
            bool IsNew = false;
            if (todoItem == null)
            {
                IsNew = true;
                todoItem = new TodoItem("") { ListId = _currentListId};
                todoItem.SetStatus(StatusOptions[0]);
            }

            if (StatusOptions == null) throw new NullReferenceException();

            List<TodoTag> allTags = _service.GetAllTags();

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

            if (result.Title != null)
            {
                todoItem.SetTodoTitle(result.Title);
                Status _status = StatusOptions.Find(status => status.Title == result.Status);
                todoItem.SetStatus(_status);
                todoItem.ListId = _service.GetTodoList(result.ListTitle).Id;
                List<TodoTag> newTags = allTags.Where(tag => HasMatchingTitle(result, tag)).ToList();
                todoItem.setTags(newTags);
                todoItem.SetDescription(result.Description);
                _service.UpdateDb();
                UpdateView();
            }

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
            _service.Delete(_currentListId, todoItem);
            UpdateView();
        }

        /// <summary>
        /// Updates the Status of a <see cref="TodoItem"/>.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <param name="Status">The Status.</param>
        public void UpdateStatus(TodoItem todoItem, string Status)
        {
            todoItem.SetStatus(Status);
        }

        /// <summary>
        /// Opens the options menu and updates the options.
        /// </summary>
        public void UpdateOptions()
        {
            // Set up and open options
            if (StatusOptions == null) return;
            StatusOptions = StatusOptions.OrderBy(status => status.Order).ToList();
            List<string> currentListNames = _service.GetListNames();
            List<TodoTag> allTags = _service.GetAllTags();
            List<TodoTag> addedTags = new List<TodoTag>();
            List<TodoTag> removedTags = new List<TodoTag>();

            List<(string title, Color color)> tags = allTags.Select(tag => (tag.Title, tag.Color)).ToList();
            
            TodoOptions newOptions = _view.ShowOptionsMenu(new TodoOptions {
                Status = StatusOptions.Select(status => status.ToString()).ToList(),
                ListNames = currentListNames,
                Tags = tags
            });

            // Handle updating options
            List<Status> tempStatusList = new List<Status>();
            for (int index = 0; index < newOptions.Status.Count; index++)
            {
                if (StatusOptions.Exists(status => status.Title == newOptions.Status[index]))
                {
                    Status status = StatusOptions.Find(status => status.Title == newOptions.Status[index]);
                    status.Order = index;
                    tempStatusList.Add(status);
                }
                else
                {
                    Status status = new Status(newOptions.Status[index]);
                    tempStatusList.Add(status);
                }
            }
            StatusOptions = tempStatusList;
            
            newOptions.ListNameChanges ??= new();

            var renamedFrom = newOptions.ListNameChanges.Keys.ToHashSet();
            var renamedTo = newOptions.ListNameChanges.Values.ToHashSet();

            foreach (var (OldName,NewName) in newOptions.ListNameChanges)
                _service.RenameList(OldName, NewName);

            foreach (var title in newOptions.ListNames.Except(currentListNames))
                if (!renamedTo.Contains(title))
                    _service.AddList(title);

            foreach (var title in currentListNames.Except(newOptions.ListNames))
                if (!renamedFrom.Contains(title))
                    _service.DeleteList(title);

            
            foreach (TodoTag tag in allTags)
            {
                if(newOptions.Tags.Any(optionsTag => optionsTag.Item1 == tag.Title))
                {
                    newOptions.Tags.Remove(newOptions.Tags.FirstOrDefault(optionsTag => optionsTag.Item1 == tag.Title));
                    continue;
                }
                removedTags.Add(tag);
            }
            foreach((string title, Color color) tag in newOptions.Tags)
            {
                addedTags.Add(new TodoTag(tag.title, tag.color));
            }
            
            _service.AddStatusOptions(StatusOptions.Where(status => status.Id >= 0).ToList());
            _service.AddTagOptions(addedTags);
            _service.RemoveTagOptions(removedTags);
            _service.UpdateDb();
            UpdateLists();
        }

        /// <summary>
        /// Cycles the Status on the todo item.
        /// </summary>
        /// <param name="todoItem">The todo item.</param>
        /// <param name="sender">The sender.</param>
        public void CycleStatus(TodoItem todoItem, TodoViewItem sender)
        {
            if (StatusOptions == null) return;
            int index = StatusOptions.FindIndex(Status => Status == todoItem.Status);
            todoItem.SetStatus(StatusOptions[(index+1) % StatusOptions.Count]);
            sender.Status = todoItem.Status.ToString();
            _service.UpdateDb();
        }

        public void UpdateLists()
        {
            var ListTitles = _service.GetListNames();
            if (_currentListId - 1 < ListTitles.Count)
                _view.UpdateLists(ListTitles,ListTitles[_currentListId - 1]);
            else
                _view.UpdateLists(ListTitles, ListTitles[0]);

        }

        private void UpdateSelectedList(string Title)
        {
            var SelectedList = _service.GetTodoList(Title);
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
                Status = todoItem.Status.Title,
                ListTitle = _service.GetTodoList(todoItem.ListId).Title,
                CurrentTags = todoItem.Tags.Select(tag => (tag.Title, tag.Color)).ToList(),
                Description = todoItem.Description,

            };
        }

        public ContextData GetContext()
        {
            if (StatusOptions == null) throw new NullReferenceException();
            return new ContextData
            {
                StatusOptions = StatusOptions.Select(status => status.ToString()).ToList(),
                ListNames = _service.GetListNames()
            };
        }
    }
}
