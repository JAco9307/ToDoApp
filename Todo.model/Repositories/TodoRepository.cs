using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Todo.model.Data;
using Todo.model.Entities;
using Todo.model.Interfaces;

namespace Todo.model.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private TodoDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the TodoRepository
        /// </summary>
        [ExcludeFromCodeCoverage]
        public TodoRepository()
        {
            _dbContext = TodoDbContextFactory.Create();
        }

        /// <summary>
        /// Initializes a new instance of the TodoRepository with a specific dbContext
        /// </summary>
        /// <param name="dbContext">a DbContext</param>
        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Adds a TodoItem to the database and saves it
        /// </summary>
        /// <param name="item">The TodoItem to add</param>
        /// <param name="listId">The id of list to add the item to</param>
        public void AddTodoItem(TodoItem item, int listId)
        {
            TodoList? todoList = _dbContext.TodoLists.FirstOrDefault(list => list.Id == listId);
            if (todoList == null)
            {
                todoList = AddList("New List");
                item.ListId = todoList.Id;
            }
            item.ListId = todoList.Id;
            _dbContext.TodoItems.Add(item);
            _dbContext.SaveChanges();
        }

        public TodoList AddList(string Title)
        {
            TodoList newlist = new TodoList { Title = Title };
            _dbContext.TodoLists.Add(newlist);
            _dbContext.SaveChanges();
            return newlist;
        }
        public void DeleteList(TodoList list)
        {
            _dbContext.TodoLists.Remove(list);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Deletes a TodoItem from the database
        /// </summary>
        /// <param name="todoItem">The TodoItem to delete</param>
        public void DeleteTodoItem(TodoItem todoItem)
        {
            _dbContext.TodoItems.Remove(todoItem);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// Updates all entities with unsaved changes to the database
        /// </summary>
        public void UpdateDb()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Gets a TodoList with a given Id, Creates a new list if none exist
        /// </summary>
        /// <param name="TodoListId">Id of the TodoList</param>
        /// <returns>The TodoList</returns>
        public TodoList? GetList(int TodoListId)
        {
            NewListIfNone();
            return _dbContext.TodoLists
                .Include(list => list.Items)
                .ThenInclude(item => item.Tags)
                .FirstOrDefault(list => list.Id == TodoListId);
        }
        public TodoList? GetList(string TodoListTitle)
        {
            NewListIfNone();
            return _dbContext.TodoLists
                .Include(list => list.Items)
                .ThenInclude(item => item.Tags)
                .FirstOrDefault(list => list.Title == TodoListTitle);
        }

        private void NewListIfNone()
        {
            if (!_dbContext.TodoLists.Any())
            {
                _dbContext.TodoLists.Add(new TodoList());
                _dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Gets all TodoLists
        /// </summary>
        /// <returns>The TodoLists</returns>
        public List<string> GetListNames()
        {
            return _dbContext.TodoLists
                .Select(list => list.Title).ToList();
        }

        public List<TodoList> GetLists()
        {
            return _dbContext.TodoLists 
                .Include(list => list.Items)
                .ThenInclude(item => item.Tags)
                .ToList();
        }

        /// <summary>
        /// Gets the Status options, if none exists makes a new default entry.
        /// </summary>
        /// <returns>The Status list result.</returns>
        public StatusList? GetStatusOptions()
        {
            if (!_dbContext.TodoStatusOptions.Any())
                _dbContext.TodoStatusOptions.Add(new StatusList());
            return _dbContext.TodoStatusOptions.FirstOrDefault();
        }


        public List<TodoTag>? GetAllTags()
        {
            return _dbContext.TodoTags.ToList();
        }

        public void AddTagOptions(List<TodoTag> newTags)
        {
            _dbContext.TodoTags.AddRange(newTags);
            _dbContext.SaveChanges();
        }

        public void RemoveTagOptions(List<TodoTag> tags)
        {
            _dbContext.TodoTags.RemoveRange(tags);
            _dbContext.SaveChanges();
        }
    }
}
