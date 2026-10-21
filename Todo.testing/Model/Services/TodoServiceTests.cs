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
        ListService service = new ListService(new TestTodoRepository());

        Assert.IsNotNull(service);
        Assert.IsEmpty(service.todoLists());
    }

    [TestMethod]
    public void Add_ShouldAddTodoItemToListZero()
    {
        var testrepo = new TestTodoRepository();
        ListService Listservice = new ListService(testrepo);
        TodoService Todoservice = new TodoService(testrepo);

        TodoItem todoItem = new TodoItem("Test Title");

        Listservice.Get(0);

        Todoservice.Add(todoItem);

        Assert.ContainsSingle(Listservice.todoLists());
        Assert.Contains(todoItem, Listservice.Get(0).Items);
    }

    [TestMethod]
    public void Add_ShouldAddMultipleTodoItemsToTheSameList()
    {
        var testrepo = new TestTodoRepository();
        ListService Listservice = new ListService(testrepo);
        TodoService Todoservice = new TodoService(testrepo);
        TodoItem todoItem1 = new TodoItem("Test Title");
        TodoItem todoItem2 = new TodoItem("Second Test Title");

        Listservice.Get(0);

        Todoservice.Add(todoItem1);
        Todoservice.Add(todoItem2);

        Assert.HasCount(2, Listservice.Get(0).Items);
        Assert.Contains(todoItem1, Listservice.Get(0).Items);
        Assert.Contains(todoItem2, Listservice.Get(0).Items);
    }

    [TestMethod]
    public void Delete_ShouldRemoveItemFromTodoList()
    {
        var testrepo = new TestTodoRepository();
        ListService Listservice = new ListService(testrepo);
        TodoService Todoservice = new TodoService(testrepo);
        TodoItem todoItem1 = new TodoItem("Test Title");
        TodoItem todoItem2 = new TodoItem("Second Test Title");

        Listservice.Get(0);

        Todoservice.Add(todoItem1);
        Todoservice.Add(todoItem2);

        Todoservice.Delete(todoItem1);

        Assert.HasCount(1, Listservice.todoLists()[0].Items);
        Assert.DoesNotContain(todoItem1, Listservice.todoLists()[0].Items);
        Assert.Contains(todoItem2, Listservice.todoLists()[0].Items);
    }

    [TestMethod]
    public void GetTodoList_ShouldReturnTheCorrectList()
    {
        var testrepo = new TestTodoRepository();
        ListService Listservice = new ListService(testrepo);
        TodoService Todoservice = new TodoService(testrepo);
        TodoItem todoItem1 = new TodoItem("Test Title");
        TodoItem todoItem2 = new TodoItem("Second Test Title");

        Listservice.Get(0);

        Todoservice.Add(todoItem1);
        Todoservice.Add(todoItem2);

        TodoList list = Listservice.Get(0);

        Assert.IsNotNull(list);
        Assert.HasCount(2, list.Items);
        Assert.Contains(todoItem1, Listservice.todoLists()[0].Items);
        Assert.Contains(todoItem2, Listservice.todoLists()[0].Items);
    }

    [TestMethod]
    public void GetTodoList_ShouldReturnFromRepositoryIfNotInMemory()
    {
        var testrepo = new TestTodoRepository();
        ListService Listservice = new ListService(testrepo);
        TodoService Todoservice = new TodoService(testrepo);
        TodoItem todoItem1 = new TodoItem("Test Title");
        TodoItem todoItem2 = new TodoItem("Second Test Title");

        Listservice.Get(0);

        Todoservice.Add(todoItem1);
        Todoservice.Add(todoItem2);

        TodoList list = Listservice.Get(55);

        Assert.IsNotNull(list);
        Assert.IsEmpty(list.Items);
        Assert.DoesNotContain(todoItem1, list.Items);
        Assert.DoesNotContain(todoItem2, list.Items);
    }

    [TestMethod]
    public void GetTodoList_ShouldCreateNewListIfNullFromRepository()
    {
        ListService Listservice = new ListService(new TestTodoRepository());

        TodoList list = Listservice.Get(999);

        Assert.IsNotNull(list);
        Assert.IsEmpty(list.Items);
    }
}
