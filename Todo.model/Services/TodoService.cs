using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Repositories;
using Todo.model.Serialization;

namespace Todo.model.Services
{
    public class TodoService : ITodoService
    {
        private ITodoRepository _repository;
        private readonly List<TodoList> _todoLists = new List<TodoList>();
        public IReadOnlyList<TodoList> TodoLists => _todoLists;
        private StatusList? _statusOptions;
        private List<TodoTag>? _allTags;

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
            if (_allTags != null)
                return _allTags;
            
            _allTags = _repository.GetAllTags() ?? new List<TodoTag>();
            return _allTags;
        }

        public void AddTagOptions(List<TodoTag> newTags)
        {
            
            _allTags?.AddRange(newTags);
            _repository.AddTagOptions(newTags);
        }

        public void RemoveTagOptions(List<TodoTag> tags)
        {
            _allTags?.RemoveAll(tag => tags.Contains(tag));
            _repository.RemoveTagOptions(tags);
        }

        /// <summary>
        /// Imports the json.
        /// </summary>
        /// <param name="filePath">The file path of the json file.</param>
        public bool ImportJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
            options.Converters.Add(new ColorJsonConverter());
            List<TodoList>? lists;
            try
            {
                lists = JsonSerializer.Deserialize<List<TodoList>>(json, options);
            }
            catch (Exception)
            {
                return false;
            }
            List<string> currentListNames = GetListNames();
            if (lists == null)
                return false;
            foreach (TodoList list in lists)
            {
                list.Title = CheckIfListNameAlreadyExist(list.Title + " (Imported List)", currentListNames);
                AddList(list.Title);
                TodoList newList = GetTodoList(list.Title);
                copyList(list, newList.Id);
            }
            return true;
        }

        /// <summary>
        /// Exports the json.
        /// </summary>
        /// <param name="lists">The lists.</param>
        public void ExportJson(List<TodoList> lists)
        {
            string json = JsonSerializer.Serialize(lists, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Lists.json", json);
        }

        /// <summary>
        /// Matches the list of tag with the list of allTags and returns a list of the matching elements from the allTags list.
        /// </summary>
        /// <param name="tags">The new tags.</param>
        /// <param name="allTags">All current tags in the database.</param>
        /// <returns>The list result.</returns>
        private List<TodoTag> UseExistingTags(List<TodoTag> tags, List<TodoTag> allTags)
        {
            return tags.Select(tag => FindMatchingTag(tag, allTags)).ToList();
        }

        /// <summary>
        /// Finds the matching tag.
        /// </summary>
        /// <param name="newTag">The new tag.</param>
        /// <param name="allTags">All tags.</param>
        /// <returns>The todo tag result.</returns>
        private TodoTag FindMatchingTag(TodoTag newTag, List<TodoTag> allTags)
        {
            return allTags.FirstOrDefault(tag => tag.Title == newTag.Title) ?? newTag;
        }

        /// <summary>
        /// Checks the if list name already exist recursively.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="currentTitles">The current titles in the list.</param>
        /// <returns>The string result, will always be unique.</returns>
        private string CheckIfListNameAlreadyExist(string title, List<string> currentTitles)
        {
            if (currentTitles.Contains(title))
                return CheckIfListNameAlreadyExist(title + "(1)", currentTitles);
            return title;
        }

        /// <summary>
        /// Copies items from the given list to the list in the database with the given id.
        /// </summary>
        /// <param name="fromList">The list to copy from.</param>
        /// <param name="toListId">The list id to copy to.</param>
        private void copyList(TodoList fromList, int toListId)
        {
            List<TodoTag> allTags = GetAllTags();
            foreach (TodoItem item in fromList.Items)
            {
                if (!SanitizeItem(item))
                    continue;
                item.setTags(UseExistingTags(item.Tags, allTags));
                Add(toListId, item);
            }
        }

        /// <summary>
        /// Sanitizes the data on import.
        /// </summary>
        /// <param name="item">The item to sanitize.</param>
        /// <returns>True if the operation succeeds; otherwise, false.</returns>
        private bool SanitizeItem(TodoItem item)
        {
            if (item.Title == null)
                return false;
            if (item.Title.Length > 40)
                item.SetTodoTitle(item.Title.Substring(0, 40));
            if (item.Status == null)
                item.SetTodoStatus("");
            if (item.Description == null)
                item.SetDescription("");
            if (item.Tags == null)
                item.setTags(new List<TodoTag>());

            foreach (TodoTag tag in item.Tags ?? new List<TodoTag>())
            {
                if (tag.Title == null)
                    item.Tags?.Remove(tag);
            }

            return true;
        }
    }
}
