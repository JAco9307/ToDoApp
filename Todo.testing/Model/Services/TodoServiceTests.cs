using Todo.model.Entities;
using Todo.model.Services;

namespace Todo.testing;

[TestClass]
public class TodoServiceTests
{
    [TestMethod]
    public void List_ShouldBeEmptyWhenCreated()
    {
        TodoService service = new TodoService();

        Assert.IsNotNull(service);
        Assert.IsEmpty(service.TodoLists);
    }

    [TestMethod]
    public void Add_ShouldAddTodoItemToListZero()
    {

        TodoService service = new TodoService();
        TodoItem todoItem = new TodoItem("Test Title");

        service.Add(0, todoItem);

        Assert.ContainsSingle(service.TodoLists);
        Assert.Contains(todoItem, service.TodoLists[0].Items);
    }

    [TestMethod]
    public void Add_ShouldAddMultipleTodoItemsToTheSameList()
    {
        TodoService service = new TodoService();
        TodoItem todoItem1 = new TodoItem("Test Title");
        TodoItem todoItem2 = new TodoItem("Second Test Title");

        service.Add(0, todoItem1);
        service.Add(0, todoItem2);

        Assert.HasCount(2, service.TodoLists[0].Items);
        Assert.Contains(todoItem1, service.TodoLists[0].Items);
        Assert.Contains(todoItem2, service.TodoLists[0].Items);
    }

    [TestMethod]
    public void Delete_ShouldRemoveItemFromTodoList()
    {
        TodoService service = new TodoService();
        TodoItem todoItem1 = new TodoItem("Test Title");
        TodoItem todoItem2 = new TodoItem("Second Test Title");

        service.Add(0, todoItem1);
        service.Add(0, todoItem2);

        service.Delete(0, todoItem1);

        Assert.HasCount(1, service.TodoLists[0].Items);
        Assert.DoesNotContain(todoItem1, service.TodoLists[0].Items);
        Assert.Contains(todoItem2, service.TodoLists[0].Items);
    }

    [TestMethod]
    public void GetTodoList_ShouldReturnTheCorrectList()
    {
        TodoService service = new TodoService();
        TodoItem todoItem1 = new TodoItem("Test Title");
        TodoItem todoItem2 = new TodoItem("Second Test Title");

        service.Add(0, todoItem1);
        service.Add(0, todoItem2);

        TodoList list = service.GetTodoList(0);

        Assert.IsNotNull(list);
        Assert.HasCount(2, list.Items);
        Assert.Contains(todoItem1, service.TodoLists[0].Items);
        Assert.Contains(todoItem2, service.TodoLists[0].Items);
    }

    [TestMethod]
    public void GetTodoList_ShouldThrowExceptionWhenListDoesntExist()
    {
        TodoService service = new TodoService();

        Assert.Throws<IndexOutOfRangeException>(() => service.GetTodoList(55));
    }
}
