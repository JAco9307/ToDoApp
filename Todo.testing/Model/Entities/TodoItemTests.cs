using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using Todo.model.Entities;
using Todo.model.Serialization;

namespace Todo.testing.Model.Entities;

[TestClass]
public class TodoItemTests
{
    [TestMethod]
    public void TodoItem_ShouldBeTheCorrectTitle()
    {
        TodoItem todoItem = new TodoItem("Test Title");

        Assert.IsNotNull(todoItem.Title);
        Assert.AreEqual("Test Title", todoItem.Title);
    }

    [TestMethod]
    public void TodoItem_TitleCanBeChanged()
    {
        TodoItem todoItem = new TodoItem("Old Title");
        todoItem.SetTodoTitle("New Title");

        Assert.IsNotNull(todoItem.Title);
        Assert.AreEqual("New Title", todoItem.Title);
    }

    [TestMethod]
    public void TodoItem_DescriptionShouldBeBlankOnCreate()
    {
        TodoItem todoItem = new TodoItem("Old Title");

        Assert.IsNotNull(todoItem.Description);
        Assert.AreEqual("", todoItem.Description);
    }

    [TestMethod]
    public void TodoItem_DescriptionCanBeChanged()
    {
        TodoItem todoItem = new TodoItem("Old Title");
        todoItem.SetDescription("New Description");

        Assert.IsNotNull(todoItem.Description);
        Assert.AreEqual("New Description", todoItem.Description);
    }

    [TestMethod]
    public void TodoItem_StatusShouldBeCorrectOnCreate()
    {
        TodoItem todoItem = new TodoItem("Old Title");

        Assert.IsNotNull(todoItem.Status);
        Assert.AreEqual("Not Started", todoItem.Status);
    }

    [TestMethod]
    public void TodoItem_StatusCanBeChanged()
    {
        TodoItem todoItem = new TodoItem("Old Title");
        todoItem.SetTodoStatus("New Status");

        Assert.IsNotNull(todoItem.Status);
        Assert.AreEqual("New Status", todoItem.Status);
    }

    [TestMethod]
    public void TodoItem_TagsShouldBeCorrectOnCreate()
    {
        TodoItem todoItem = new TodoItem("Old Title");

        Assert.IsNotNull(todoItem.Tags);
        Assert.AreSequenceEqual(new List<TodoTag>(), todoItem.Tags);
    }

    [TestMethod]
    public void TodoItem_TagsCanBeChanged()
    {
        TodoItem todoItem = new TodoItem("Old Title");
        List<TodoTag> tags = new List<TodoTag> { new TodoTag("New Tag", Color.Green) };

        todoItem.SetTags(tags);

        Assert.IsNotNull(todoItem.Tags);
        Assert.AreSequenceEqual(tags, todoItem.Tags);
    }

    [TestMethod]
    public void TodoItem_JsonConstructorShouldAssignItemsCorrectly()
    {
        string json = "{\r\n        \"Id\": 1,\r\n        \"ListId\": 2,\r\n        \"Title\": \"A Title\",\r\n        " +
            "\"Description\": \"A Description\",\r\n        \"Status\": \"In Progress\",\r\n        \"Tags\": [\r\n          " +
            "{\r\n            \"Id\": -2,\r\n            \"Title\": \"Important\",\r\n            \"Color\": {\r\n   " +
            "           \"R\": 255,\r\n              \"G\": 255,\r\n              \"B\": 0,\r\n              \"A\": " +
            "255,\r\n              \"IsKnownColor\": false,\r\n              \"IsEmpty\": false,\r\n              " +
            "\"IsNamedColor\": false,\r\n              \"IsSystemColor\": false,\r\n              \"Name\": \"ffffff00" +
            "\"\r\n            }\r\n          }\r\n        ]\r\n      }";

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve
        };
        options.Converters.Add(new ColorJsonConverter());
        TodoItem? todoItem = JsonSerializer.Deserialize<TodoItem>(json, options);

        if(todoItem == null) Assert.Fail();

        Assert.IsNotNull(todoItem.Tags);
        Assert.AreEqual(0, todoItem.Id);
        Assert.AreEqual(2, todoItem.ListId);
        Assert.AreEqual("A Description", todoItem.Description);
        Assert.AreEqual("In Progress", todoItem.Status);
        Assert.AreEqual("A Title", todoItem.Title);
        foreach(TodoTag tag in todoItem.Tags)
        {
            Assert.AreEqual("Important", tag.Title);
            Assert.AreEqual(Color.FromArgb(255,255,255,0), tag.Color);
        }
    }


}
