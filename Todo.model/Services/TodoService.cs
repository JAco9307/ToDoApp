using System.Diagnostics.CodeAnalysis;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Repositories;

namespace Todo.model.Services
{
    public class TodoService : ITodoService
    {
        private ITodoRepository _repository;
        private readonly List<TodoList> _todoLists = new List<TodoList>();
        public IReadOnlyList<TodoList> TodoLists => _todoLists;
        private StatusList? _statusOptions;

        [ExcludeFromCodeCoverage]
        public TodoService()
        {
            _repository = new TodoRepository();
            var lists = _repository.GetLists();
            foreach (var list in lists)
                _todoLists.Add(list);
        }

        public TodoService(ITodoRepository todoRepository)
        {
            _repository = todoRepository;
            var lists = _repository.GetLists();
            foreach (var list in lists)
                _todoLists.Add(list);

        }

        /// <summary>
        /// Adds the TodoItem to the TodoList with the given ID. 
        /// Creates a new TodoList if none exist. 
        /// Throws an IndexOutOfRange exception if ID doesnt exist.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="todoItem">The TodoItem.</param>
        public void Add(int listId, TodoItem todoItem)
        {
            _todoLists.Find(list => list.Id == listId)?.Add(todoItem);
            _repository.AddTodoItem(todoItem, listId);
        }
        /// <summary>
        /// Updates all entities in database
        /// </summary>
        public void UpdateDb()
        {
            _repository.UpdateDb();
        }

        /// <summary>
        /// Deletes the TodoItem from the TodoList with the given ID. 
        /// Throws an IndexOutOfRange exception if ID doesnt exist.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="todoItem">The TodoItem.</param>
        public void Delete(int listId, TodoItem todoItem)
        {
            _todoLists.First(list => list.Id == listId).Remove(todoItem);
            _repository.UpdateDb();
        }

        /// <summary>
        /// Gets the todo list with the given ID,
        /// If list is not found in service layer it checks database,
        /// If not found in database it creates a new list.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <returns>The TodoList.</returns>
        public TodoList GetTodoList(int listId)
        {
            TodoList? list = _todoLists.Find(list => list.Id == listId);
            if (list != null)
                return list;

            list = _repository.GetList(listId) ?? new TodoList(listId);

            _todoLists.Add(list);
            return list;
        }
        public TodoList GetTodoList(string listTitle)
        {
            TodoList? list = _todoLists.Find(list => list.Title == listTitle);
            if (list != null)
                return list;

            list = _repository.GetList(listTitle) ?? new TodoList { Title = listTitle };

            _todoLists.Add(list);
            return list;
        }


        /// <summary>
        /// Adds a new list to the repository.
        /// </summary>
        /// <param name="Title">The list's title.</param>
        public void AddList(string Title)
        {
            _repository.AddList(Title);
        }

        /// <summary>
        /// Deletes a list.
        /// </summary>
        /// <param name="Title">The title.</param>
        public void DeleteList(string Title)
        {
            var list = _todoLists.FirstOrDefault(list => list.Title == Title);
            if (list == null) return;
            _todoLists.Remove(list);
            _repository.DeleteList(list);
        }

        /// <summary>
        /// Renames a list by name.
        /// </summary>
        /// <param name="TitleOld">The current title .</param>
        /// <param name="TitleNew">The new title .</param>
        public void RenameList(string TitleOld, string TitleNew)
        {
            var list = _todoLists.FirstOrDefault(list => list.Title == TitleOld);
            if (list == null) return;
            list.Title = TitleNew;
            UpdateDb();
        }

        /// <summary>
        /// Gets the status options.
        /// </summary>
        /// <returns>The status list result.</returns>
        public StatusList GetStatusOptions()
        {
            if (_statusOptions == null)
            {
                StatusList? list = _repository.GetStatusOptions();
                _statusOptions = list ?? new StatusList();
            }
            return _statusOptions;
        }

        /// <summary>
        /// Gets the list names. If no lists are found, creates a new empty list
        /// </summary>
        /// <returns>The list result.</returns>
        public List<string> GetListNames()
        {
            _repository.UpdateDb();
            List<string> output = _repository.GetListNames();
            if (output.Count == 0 && _todoLists.Count == 0)
            {
                TodoList list = new TodoList(1);
                _todoLists.Add(list);
                output.Add(list.Title);

            }
            if (output.Count == 0 && _todoLists.Count != 0) //not sure why this check is nessesary but it is
            {
                output.Add(_todoLists[0].Title);
            }
            return output;
        }

        public List<TodoTag> GetAllTags()
        {
            return _repository.GetAllTags() ?? new List<TodoTag>();
        }

        public void AddTagOptions(List<TodoTag> newTags)
        {
            _repository.AddTagOptions(newTags);
        }

        public void RemoveTagOptions(List<TodoTag> newTags)
        {
            _repository.RemoveTagOptions(newTags);
        }
    }
}
