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

        Assert.IsEmpty(service.todoLists);
    }

    //[TestMethod]
    //public void Add_ShouldAddTodoItemToListZero()
    //{

    //    TodoService service = new TodoService();
    //    TodoItem todoItem = new TodoItem("Test Title");

    //    service.Add(0, todoItem);

    //    Assert.ContainsSingle(service.todoLists);
    //    Assert.Contains(todoItem, service.todoLists[0].Items);
    //}

    //[TestMethod]
    //public void Add_ShouldAddMultipleTodoItemsToTheSameList()
    //{
    //    TodoService service = new TodoService();
    //    TodoItem todoItem1 = new TodoItem("Test Title");
    //    TodoItem todoItem2 = new TodoItem("Second Test Title");

    //    service.Add(0, todoItem1);
    //    service.Add(0, todoItem2);

    //    Assert.HasCount(2, service.todoLists);
    //    Assert.Contains(todoItem1, service.todoLists[0].Items);
    //    Assert.Contains(todoItem2, service.todoLists[0].Items);
    //}
}
