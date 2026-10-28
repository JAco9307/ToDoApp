using Todo.model.Entities;

namespace Todo.testing;

[TestClass]
public class TodoListTests
{
    [TestMethod]
    public void List_ShouldNotBeNullBeforeAdd()
    {
        TodoList list = new TodoList();
        TodoItem todoItem = new TodoItem("Test Title", new Status(""));


        Assert.IsNotNull(list.Items);
    }

    [TestMethod]
    public void List_ShouldBeEmptyAtStart()
    {
        TodoList list = new TodoList();
        TodoItem todoItem = new TodoItem("Test Title", new Status(""));

        Assert.IsEmpty(list.Items);
    }

    [TestMethod]
    public void Add_ShouldAddTheTodoItemToTheList()
    {
        TodoList list = new TodoList();
        TodoItem todoItem = new TodoItem("Test Title", new Status(""));

        list.Add(todoItem);

        Assert.ContainsSingle(list.Items);
        Assert.Contains(todoItem, list.Items);
    }

    [TestMethod]
    public void Add_ShouldAddMultipleTodos()
    {
        TodoList list = new TodoList();
        TodoItem todoItem1 = new TodoItem("Test Title", new Status(""));
        TodoItem todoItem2 = new TodoItem("Second Test Title", new Status(""));

        list.Add(todoItem1);
        list.Add(todoItem2);

        Assert.HasCount(2, list.Items);
        Assert.Contains(todoItem1, list.Items);
        Assert.Contains(todoItem2, list.Items);
    }

    [TestMethod]
    public void Remove_ShouldRemoveTheTodoItemToTheList()
    {
        TodoList list = new TodoList();
        TodoItem todoItem = new TodoItem("Test Title", new Status(""));

        list.Add(todoItem);

        list.Remove(todoItem);

        Assert.DoesNotContain(todoItem, list.Items);
    }

    [TestMethod]
    public void Remove_ShouldRemoveTheCorrectTodoItemToTheList()
    {
        TodoList list = new TodoList();
        TodoItem todoItem1 = new TodoItem("Test Title", new Status(""));
        TodoItem todoItem2 = new TodoItem("Second Test Title", new Status(""));

        list.Add(todoItem1);
        list.Add(todoItem2);

        list.Remove(todoItem1);

        Assert.ContainsSingle(list.Items);
        Assert.DoesNotContain(todoItem1, list.Items);
        Assert.Contains(todoItem2, list.Items);
    }

    [TestMethod]
    public void Remove_ShouldThrowExceptionIfTodoNotFound()
    {
        TodoList list = new TodoList();
        TodoItem todoItem = new TodoItem("Test Title", new Status(""));

        Assert.Throws<KeyNotFoundException>(() => list.Remove(todoItem));
    }
}
