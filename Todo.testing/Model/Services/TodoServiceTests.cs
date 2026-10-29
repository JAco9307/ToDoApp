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

        public List<Status> GetStatusOptions()
        {
            return null;
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

        public void AddStatusOptions(List<Status> statusToAdd)
        {
            throw new NotImplementedException();
        }

        public void DeleteStatusOptions(List<Status> statusToDelete)
        {
            throw new NotImplementedException();
        }
    }

    public ListService Listservice = new ListService();
    public TodoService Todoservice = new TodoService();

    [TestInitialize]
    public void initial() 
    {
        var testrepo = new TestTodoRepository();
        Listservice = new ListService(testrepo);
        Todoservice = new TodoService(testrepo);
    }

    public ListService Listservice = new ListService();
    public TodoService Todoservice = new TodoService();

    [TestInitialize]
    public void initial()
    {
        var testrepo = new TestTodoRepository();
        Listservice = new ListService(testrepo);
        Todoservice = new TodoService(testrepo);
    }

    [TestMethod]
    public void List_ShouldBeEmptyWhenCreated()
    {
        Assert.IsNotNull(Listservice);
        Assert.IsEmpty(Listservice.todoLists());
    }

    [TestMethod]
    public void Add_ShouldAddTodoItemToListZero()
    {
        TodoItem todoItem = new TodoItem("Test Title", new Status(""));

        Listservice.Get(0);

        Todoservice.Add(todoItem);

        Assert.ContainsSingle(Listservice.todoLists());
        Assert.Contains(todoItem, Listservice.Get(0).Items);
    }

    [TestMethod]
    public void Add_ShouldAddMultipleTodoItemsToTheSameList()
    {
        TodoItem todoItem1 = new TodoItem("Test Title", new Status(""));
        TodoItem todoItem2 = new TodoItem("Second Test Title", new Status(""));

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
        TodoItem todoItem1 = new TodoItem("Test Title", new Status(""));
        TodoItem todoItem2 = new TodoItem("Second Test Title", new Status(""));

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
        TodoItem todoItem1 = new TodoItem("Test Title", new Status(""));
        TodoItem todoItem2 = new TodoItem("Second Test Title", new Status(""));

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
        TodoItem todoItem1 = new TodoItem("Test Title", new Status(""));
        TodoItem todoItem2 = new TodoItem("Second Test Title", new Status(""));

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

        TodoList list = Listservice.Get(999);

        Assert.IsNotNull(list);
        Assert.IsEmpty(list.Items);
    }
}
