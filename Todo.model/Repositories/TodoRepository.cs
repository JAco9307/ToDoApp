using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
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

        //interface
        public void AddTodoItem(TodoItem item)
        {
            TodoList? todoList = _dbContext.TodoLists.FirstOrDefault(list => list.Id == item.ListId);
            if (todoList == null)
            {
                todoList = AddList("New List");
                item.ListId = todoList.Id;
            }
            item.ListId = todoList.Id;
            _dbContext.TodoItems.Add(item);
            _dbContext.SaveChanges();
        }

        public void DeleteTodoItem(TodoItem todoItem)
        {
            _dbContext.TodoItems.Remove(todoItem);
            _dbContext.SaveChanges();
        }

        //interface
        public TodoList AddList(string Title)
        {
            TodoList newlist = new TodoList { Title = Title };
            _dbContext.TodoLists.Add(newlist);
            _dbContext.SaveChanges();
            return newlist;
        }

        //interface
        public void DeleteList(TodoList list)
        {
            if (!_dbContext.TodoLists.Contains(list)) return;
            _dbContext.TodoLists.Remove(list);
            _dbContext.SaveChanges();
        }

        //interface
        public void UpdateDb()
        {
            _dbContext.SaveChanges();
        }

        //interface
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

        /// <summary>
        /// Creates a new empty list if none exist in the database.
        /// </summary>
        private void NewListIfNone()
        {
            if (!_dbContext.TodoLists.Any())
            {
                _dbContext.TodoLists.Add(new TodoList());
                _dbContext.SaveChanges();
            }
        }

        //interface
        public List<string> GetListNames()
        {
            return _dbContext.TodoLists
                .Select(list => list.Title).ToList();
        }

        //interface
        public List<TodoList> GetLists()
        {
            return _dbContext.TodoLists
                .Include(list => list.Items)
                .ToList();
        }

        //interface
        public List<Status> GetStatusOptions()
        {
            return _dbContext.TodoStatus.ToList();
        }


        //interface
        public List<TodoTag>? GetAllTags()
        {
            return _dbContext.TodoTags.ToList();
        }

        //interface
        public void AddTagOptions(List<TodoTag> newTags)
        {
            _dbContext.TodoTags.AddRange(newTags);
            _dbContext.SaveChanges();
        }

        //interface
        public void RemoveTagOptions(List<TodoTag> tags)
        {
            _dbContext.TodoTags.RemoveRange(tags);
            _dbContext.SaveChanges();
        }
        //interface
        public void AddStatusOptions(List<Status> statusToAdd)
        {
            _dbContext.TodoStatus.AddRange(statusToAdd);
            _dbContext.SaveChanges();
        }
        //interface
        public void DeleteStatusOptions(List<Status> statusToDelete)
        {
            _dbContext.TodoStatus.RemoveRange(statusToDelete);
            _dbContext.SaveChanges();
        }
    }
}
