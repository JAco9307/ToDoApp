using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Services;

namespace Todo.testing;

[TestClass]
public class TodoServiceTests
{
    private class TestTodoRepository : ITodoRepository
    {
        private TodoList _todoList = new TodoList();
        public void AddTodoItem(TodoItem todoItem)
        {
            _todoList.Add(todoItem);
        }

        public void DeleteTodoItem(TodoItem todoItem)
        {
            _todoList.Remove(todoItem);
        }

        public void UpdateDb()
        {
        }

        public TodoList? GetList(int TodoListId)
        {
            if (TodoListId == 999)
                return null;
            if (TodoListId == 55)
                return new TodoList(55);
            return _todoList;
        }

        public StatusList? GetStatusOptions()
        {
            return null;
        }

        public void UpdateStatusOptions(StatusList StatusOptions)
        {

        }

        public void AddTodoItem(TodoItem todoItem, int listId)
        {

        }

        public TodoList AddList(string Title)
        {
            return new();
        }

        public void DeleteList(TodoList list)
        {

        }

        public List<string> GetListNames()
        {
            return new();

        }

        public List<TodoList> GetLists()
        {
            return new();
        }

        public TodoList? GetList(string TodoListTitle)
        {
            throw new NotImplementedException();
        }

        public List<TodoTag>? GetAllTags()
        {
            throw new NotImplementedException();
        }

        public void AddTagOptions(List<TodoTag> newTags)
        {
            throw new NotImplementedException();
        }

        public void RemoveTagOptions(List<TodoTag> newTags)
        {
            throw new NotImplementedException();
        }
    }

    [TestMethod]
    public void List_ShouldBeEmptyWhenCreated()
    {
        TodoService service = new TodoService(new TestTodoRepository());

        Assert.IsNotNull(service);
        Assert.IsEmpty(service.TodoLists);
    }

    [TestMethod]
    public void Add_ShouldAddTodoItemToListZero()
    {

        TodoService service = new TodoService(new TestTodoRepository());
        TodoItem todoItem = new TodoItem("Test Title");

        service.GetTodoList(0);

        service.Add(0, todoItem);

        Assert.ContainsSingle(service.TodoLists);
        Assert.Contains(todoItem, service.TodoLists[0].Items);
    }

    [TestMethod]
    public void Add_ShouldAddMultipleTodoItemsToTheSameList()
    {
        TodoService service = new TodoService(new TestTodoRepository());
        TodoItem todoItem1 = new TodoItem("Test Title");
        TodoItem todoItem2 = new TodoItem("Second Test Title");

        service.GetTodoList(0);

        service.Add(0, todoItem1);
        service.Add(0, todoItem2);

        Assert.HasCount(2, service.TodoLists[0].Items);
        Assert.Contains(todoItem1, service.TodoLists[0].Items);
        Assert.Contains(todoItem2, service.TodoLists[0].Items);
    }

    [TestMethod]
    public void Delete_ShouldRemoveItemFromTodoList()
    {
        TodoService service = new TodoService(new TestTodoRepository());
        TodoItem todoItem1 = new TodoItem("Test Title");
        TodoItem todoItem2 = new TodoItem("Second Test Title");

        service.GetTodoList(0);

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
        TodoService service = new TodoService(new TestTodoRepository());
        TodoItem todoItem1 = new TodoItem("Test Title");
        TodoItem todoItem2 = new TodoItem("Second Test Title");

        service.GetTodoList(0);

        service.Add(0, todoItem1);
        service.Add(0, todoItem2);

        TodoList list = service.GetTodoList(0);

        Assert.IsNotNull(list);
        Assert.HasCount(2, list.Items);
        Assert.Contains(todoItem1, service.TodoLists[0].Items);
        Assert.Contains(todoItem2, service.TodoLists[0].Items);
    }

    [TestMethod]
    public void GetTodoList_ShouldReturnFromRepositoryIfNotInMemory()
    {
        TodoService service = new TodoService(new TestTodoRepository());
        TodoItem todoItem1 = new TodoItem("Test Title");
        TodoItem todoItem2 = new TodoItem("Second Test Title");

        service.GetTodoList(0);

        service.Add(0, todoItem1);
        service.Add(0, todoItem2);

        TodoList list = service.GetTodoList(55);

        Assert.IsNotNull(list);
        Assert.IsEmpty(list.Items);
        Assert.DoesNotContain(todoItem1, list.Items);
        Assert.DoesNotContain(todoItem2, list.Items);
    }

    [TestMethod]
    public void GetTodoList_ShouldCreateNewListIfNullFromRepository()
    {
        TodoService service = new TodoService(new TestTodoRepository());

        TodoList list = service.GetTodoList(999);

        Assert.IsNotNull(list);
        Assert.IsEmpty(list.Items);
    }
}
