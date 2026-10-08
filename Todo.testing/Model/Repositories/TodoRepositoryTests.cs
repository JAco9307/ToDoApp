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

        TodoItem todoItem = new TodoItem("this is a todo item");
        repository.AddTodoItem(todoItem);

        TodoItem? savedTodoItem = dbContext.TodoItems.SingleOrDefault(x => x.Title == "this is a todo item");
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

        TodoItem todoItem = new TodoItem("this is a todo item");
        repository.AddTodoItem(todoItem);
        repository.DeleteTodoItem(todoItem);
        TodoItem? savedTodoItem = dbContext.TodoItems.SingleOrDefault(x => x.Title == "this is a todo item");
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
        Assert.AreEqual(todoList,todoListFromDb);
    }

    [TestMethod]
    public void ChangeTodoItem()
    {
        SqliteConnection connection = PrepareConnection();
        TodoDbContext dbContext = prepareContext(connection);

        connection.Open();
        dbContext.Database.EnsureCreated();
        ITodoRepository repository = new TodoRepository(dbContext);
        TodoItem todoItem = new TodoItem("item");
        
        repository.AddTodoItem(todoItem);
        todoItem.SetTodoTitle("Changed");
        repository.UpdateTodoItem(todoItem);
        Assert.AreEqual("Changed",dbContext.TodoItems.Find(todoItem.Id).Title);
    }
}