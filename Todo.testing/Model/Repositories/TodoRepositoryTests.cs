using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Todo.model.Data;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Repositories;

namespace Todo.testing.Model.Repositories;

[TestClass]
public class TodoRepositoryTests
{

    private SqliteConnection PrepareConnection()
    {
        return new SqliteConnection("Datasource=:memory:");
    }

    private TodoDbContext prepareContext(SqliteConnection connection)
    {
        DbContextOptions<TodoDbContext> options = new DbContextOptionsBuilder<TodoDbContext>().UseSqlite(connection).Options;

        return new TodoDbContext(options);
    }

    [TestMethod]
    public void AddTodoItemTest()
    {
        SqliteConnection connection = PrepareConnection();
        TodoDbContext dbContext = prepareContext(connection);

        connection.Open();
        dbContext.Database.EnsureCreated();
        ITodoRepository repository = new TodoRepository(dbContext);

        Status status = repository.GetStatusOptions()[0];
        TodoItem todoItem = new TodoItem("this is a todo item", new Status(""));
        repository.AddTodoItem(todoItem);

        TodoItem? savedTodoItem = dbContext.TodoItems.SingleOrDefault(todoItem => todoItem.Title == "this is a todo item");
        Assert.AreEqual(todoItem, savedTodoItem);
    }

    [TestMethod]
    public void DeleteTodoItemTest()
    {
        SqliteConnection connection = PrepareConnection();
        TodoDbContext dbContext = prepareContext(connection);

        connection.Open();
        dbContext.Database.EnsureCreated();
        ITodoRepository repository = new TodoRepository(dbContext);

        TodoItem todoItem = new TodoItem("this is a todo item", new Status(""));
        repository.AddTodoItem(todoItem);
        repository.DeleteTodoItem(todoItem);
        TodoItem? savedTodoItem = dbContext.TodoItems.SingleOrDefault(todoItem => todoItem.Title == "this is a todo item");
        Assert.IsNull(savedTodoItem);
    }

    [TestMethod]
    public void GetTodoListTest()
    {
        SqliteConnection connection = PrepareConnection();
        TodoDbContext dbContext = prepareContext(connection);

        connection.Open();
        dbContext.Database.EnsureCreated();
        ITodoRepository repository = new TodoRepository(dbContext);

        TodoList todoList = new TodoList();
        dbContext.TodoLists.Add(todoList);
        dbContext.SaveChanges();
        TodoList? todoListFromDb = repository.GetList(1);
        Assert.AreEqual(todoList, todoListFromDb);
    }

    [TestMethod]
    public void ChangeTodoItem()
    {
        SqliteConnection connection = PrepareConnection();
        TodoDbContext dbContext = prepareContext(connection);

        connection.Open();
        dbContext.Database.EnsureCreated();
        ITodoRepository repository = new TodoRepository(dbContext);
        TodoItem todoItem = new TodoItem("item", new Status(""));

        repository.AddTodoItem(todoItem);
        todoItem.SetTodoTitle("Changed");
        repository.UpdateDb();
        Assert.AreEqual("Changed", dbContext.TodoItems.Find(todoItem.Id).Title);
    }

    [TestMethod]
    public void AddTodoItemWithDescriptionTest()
    {
        SqliteConnection connection = PrepareConnection();
        TodoDbContext dbContext = prepareContext(connection);

        connection.Open();
        dbContext.Database.EnsureCreated();
        ITodoRepository repository = new TodoRepository(dbContext);

        string TitleString = new("this is a todo item");
        string DescString = new("This is a description");
        TodoItem todoItem = new TodoItem(TitleString, new Status(""), DescString);
        repository.AddTodoItem(todoItem);

        TodoItem savedTodoItem = dbContext.TodoItems.Find(1)!;
        Assert.AreEqual(savedTodoItem.Description, DescString);
    }

    [TestMethod]
    public void AddStatusTest()
    {
        SqliteConnection connection = PrepareConnection();
        TodoDbContext dbContext = prepareContext(connection);

        connection.Open();
        dbContext.Database.EnsureCreated();
        ITodoRepository repository = new TodoRepository(dbContext);

        string statusTitle = "Status Title";
        Status status = new Status(statusTitle);
        repository.AddStatusOptions(new List<Status> {status});

        Assert.AreEqual(statusTitle,repository.GetStatusOptions()[3].Title);
    }

    [TestMethod]
    public void RemoveSingleStatusTest()
    {
        SqliteConnection connection = PrepareConnection();
        TodoDbContext dbContext = prepareContext(connection);

        connection.Open();
        dbContext.Database.EnsureCreated();
        ITodoRepository repository = new TodoRepository(dbContext);

        int statusAmounts = repository.GetStatusOptions().Count;
        Status statusToRemove = repository.GetStatusOptions()[0];
        repository.DeleteStatusOptions(new List<Status>{statusToRemove});
        
        Assert.AreEqual(statusAmounts-1, repository.GetStatusOptions().Count);
    }
    
    [TestMethod]
    public void RemoveSeveralStatusTest()
    {
        SqliteConnection connection = PrepareConnection();
        TodoDbContext dbContext = prepareContext(connection);

        connection.Open();
        dbContext.Database.EnsureCreated();
        ITodoRepository repository = new TodoRepository(dbContext);
        
        repository.DeleteStatusOptions(repository.GetStatusOptions());
        Assert.AreEqual(0, repository.GetStatusOptions().Count);
    }

    [TestMethod]
    public void RenameStatusTest()
    {
        SqliteConnection connection = PrepareConnection();
        TodoDbContext dbContext = prepareContext(connection);

        connection.Open();
        dbContext.Database.EnsureCreated();
        ITodoRepository repository = new TodoRepository(dbContext);

        string statusTitleToSet = "New Status Title";
        repository.GetStatusOptions()[0].Title = statusTitleToSet;
        repository.UpdateDb();
        string newStatusTitle = repository.GetStatusOptions()[0].Title;
        
        Assert.AreEqual(statusTitleToSet, newStatusTitle);
    }

    [TestMethod]
    public void RemoveStatusRemovedTodoTest()
    {
        SqliteConnection connection = PrepareConnection();
        TodoDbContext dbContext = prepareContext(connection);

        connection.Open();
        dbContext.Database.EnsureCreated();
        ITodoRepository repository = new TodoRepository(dbContext);

        Status status = repository.GetStatusOptions()[0];
        TodoList list;
        TodoItem todoItem = new TodoItem("todo", status);
        repository.AddTodoItem(todoItem);
        list = repository.GetLists()[0];
        Assert.AreEqual(1, list.Items.Count);
        repository.DeleteStatusOptions(new List<Status>{status});
        list = repository.GetLists()[0];
        Assert.AreEqual(0, list.Items.Count);
    }
}