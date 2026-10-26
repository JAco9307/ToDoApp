using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Todo.model.Data;
using Todo.model.Entities;
using Todo.model.Interfaces;

namespace Todo.model.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        TodoDbContext? _dbContext;

        /// <summary>
        /// Initializes a new instance of the TodoRepository
        /// </summary>
        [ExcludeFromCodeCoverage]
        public TodoRepository()
        {
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
        public async void AddTodoItem(TodoItem item, TodoDbContext? context = null)
        {
            await using TodoDbContext dbContext = context ?? TodoDbContextFactory.Create();

            TodoList? todoList = await dbContext.TodoLists.FirstOrDefaultAsync(list => list.Id == item.ListId);
            if (todoList == null)
            {
                todoList = await AddListWithContext("New List", dbContext);
                item.ListId = todoList.Id;
            }
            item.ListId = todoList.Id;
            await dbContext.TodoItems.AddAsync(item);
            await dbContext.SaveChangesAsync();
        }

        public async void DeleteTodoItem(TodoItem todoItem, TodoDbContext? context = null)
        {
            await using TodoDbContext dbContext = context ?? TodoDbContextFactory.Create();

            dbContext.TodoItems.Remove(todoItem);
            dbContext.SaveChanges();
        }

        //interface
        public async Task<TodoList> AddList(string Title)
        {
            await using TodoDbContext dbContext = TodoDbContextFactory.Create();

            return await AddListWithContext(Title, dbContext);
        }

        //interface
        private async Task<TodoList> AddListWithContext(string Title, TodoDbContext dbContext)
        {

            TodoList newlist = new TodoList { Title = Title };
            await dbContext.TodoLists.AddAsync(newlist);
            await dbContext.SaveChangesAsync();
            return newlist;
        }

        //interface
        public async void DeleteList(TodoList list, TodoDbContext? context = null)
        {
            await using TodoDbContext dbContext = context ?? TodoDbContextFactory.Create();

            if (!dbContext.TodoLists.Contains(list)) return;
            dbContext.TodoLists.Remove(list);
            dbContext.SaveChanges();
        }

        //interface
        public async void UpdateDb(TodoDbContext? context = null)
        {
            await using TodoDbContext dbContext = context ?? TodoDbContextFactory.Create();

            dbContext.SaveChanges();
        }

        //interface
        public async Task<TodoList?> GetList(int TodoListId, TodoDbContext? context = null)
        {
            await using TodoDbContext dbContext = context ?? TodoDbContextFactory.Create();

            List<TodoItem> temp = await dbContext.TodoItems
                .Where(item => item.ListId == TodoListId)
                .ToListAsync();

            NewListIfNone(dbContext);
            return await dbContext.TodoLists
                .Include(list => list.Items)
                .ThenInclude(item => item.Tags)
                .FirstOrDefaultAsync(list => list.Id == TodoListId);
        }
        public async Task<TodoList?> GetList(string TodoListTitle, TodoDbContext? context = null)
        {
            await using TodoDbContext dbContext = context ?? TodoDbContextFactory.Create();

            NewListIfNone(dbContext);
            return dbContext.TodoLists
                .Include(list => list.Items)
                .ThenInclude(item => item.Tags)
                .FirstOrDefault(list => list.Title == TodoListTitle);
        }

        /// <summary>
        /// Creates a new empty list if none exist in the database.
        /// </summary>
        private async void NewListIfNone(TodoDbContext dbContext, TodoDbContext? context = null)
        {
            if (!dbContext.TodoLists.Any())
            {
                await dbContext.TodoLists.AddAsync(new TodoList());
                await dbContext.SaveChangesAsync();
            }
        }

        //interface
        public async Task<List<string>> GetListNames(TodoDbContext? context = null)
        {
            await using TodoDbContext dbContext = context ?? TodoDbContextFactory.Create();

            return dbContext.TodoLists
            .Select(list => list.Title).ToList();
        }

        //interface
        public async Task<List<TodoList>> GetLists(TodoDbContext? context = null)
        {
            await using TodoDbContext dbContext = context ?? TodoDbContextFactory.Create();

            return dbContext.TodoLists
            .Include(list => list.Items)
            .ThenInclude(item => item.Tags)
            .ToList();
        }

        //interface
        public async Task<StatusList?> GetStatusOptions(TodoDbContext? context = null)
        {
            await using TodoDbContext dbContext = context ?? TodoDbContextFactory.Create();

            if (!dbContext.TodoStatusOptions.Any())
                dbContext.TodoStatusOptions.Add(new StatusList());
            return dbContext.TodoStatusOptions.FirstOrDefault();
        }


        //interface
        public async Task<List<TodoTag>?> GetAllTags(TodoDbContext? context = null)
        {
            await using TodoDbContext dbContext = context ?? TodoDbContextFactory.Create();

            return dbContext.TodoTags.ToList();
        }

        //interface
        public async void AddTagOptions(List<TodoTag> newTags, TodoDbContext? context = null)
        {
            await using TodoDbContext dbContext = context ?? TodoDbContextFactory.Create();

            dbContext.TodoTags.AddRange(newTags);
            dbContext.SaveChanges();
        }

        //interface
        public async void RemoveTagOptions(List<TodoTag> tags, TodoDbContext? context = null)
        {
            await using TodoDbContext dbContext = context ?? TodoDbContextFactory.Create();

            dbContext.TodoTags.RemoveRange(tags);
            dbContext.SaveChanges();
        }
    }
}
