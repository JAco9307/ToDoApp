using Todo.model.Entities;

namespace Todo.testing.Model.Entities;

[TestClass]
public class TodoItemTests
{
    [TestMethod]
    public void TodoItem_ShouldBeTheCorrectTitle()
    {
        TodoItem todoItem = new TodoItem("Test Title", new Status(""));

        Assert.IsNotNull(todoItem.Title);
        Assert.AreEqual("Test Title", todoItem.Title);
    }

    [TestMethod]
    public void TodoItem_TitleCanBeChanged()
    {
        TodoItem todoItem = new TodoItem("Old Title", new Status(""));
        todoItem.SetTodoTitle("New Title");

        Assert.IsNotNull(todoItem.Title);
        Assert.AreEqual("New Title", todoItem.Title);
    }
}
