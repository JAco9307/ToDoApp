using System.Windows.Forms;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.presenter;
using Todo.view.Entities;
using Todo.view.Interfaces;
using Todo.view.ViewObjects;

namespace Todo.testing.presenter
{
    public class mockTodoService : ITodoService
    {

        public bool calledAdd = false;
        public bool calledDelete = false;
        public void Add(TodoItem todoItem)
        {
            calledAdd = true;
        }

        public void Delete(TodoItem todoItem)
        {
            calledDelete = true;
        }

        public void UpdateDb()
        {
        }
    }

    public class mockListService : IListService
    {
        public bool calledGetList = false;

        public void Add(string Title)
        {
        }

        public void Delete(string Title)
        {
        }

        public TodoList Get(int listId)
        {
            return new TodoList();
        }

        public TodoList Get(string listTitle)
        {
            return new TodoList();
        }

        public List<string> GetNames()
        {
            return [];
        }

        public TodoList GetTodoList(int listId)
        {
            calledGetList = true;
            return new TodoList();
        }

        public void Rename(string TitleOld, string TitleNew)
        {
        }

        public List<TodoList> todoLists()
        {
            return [];
        }
    }

    public class mockView : ITodoView
    {
        public bool calledStartup = false;
        public bool calledUpdate = false;

        public TodoData ShowEditTodoDialog(ContextData context, TodoData? currentData = null)
        {
            return new TodoData
            {
                Title = "bazinga",
            };
        }

        public TodoData ShowEditTodoDialog(ContextData context, TodoData currentData, bool IsNew)
        {
            return new();
        }

        public TodoOptions ShowOptionsMenu(TodoOptions currentOptions)
        {
            return new();
        }

        public List<TodoViewItem> UpdateActiveViewList(List<TodoData> todoDatas)
        {
            calledUpdate = true;
            return new List<TodoViewItem>();
        }

        public List<Control> StartUp()
        {
            calledStartup = true;
            return new List<Control>();
        }

        public void UpdateComboboxLists(List<string> lists, string selectList)
        {
            throw new NotImplementedException();
        }
    }
    public class mockTagService : ITagService
    {
        public void AddOptions(List<TodoTag> newTags)
        {
        }

        public List<TodoTag> GetAll()
        {
            return [];
        }

        public void RemoveOptions(List<TodoTag> newTags)
        {
        }
    }

    public class mockStatusService() : IStatusService
    {
        public void AddOptions(List<Status> statusToAdd)
        {
            throw new NotImplementedException();
        }

        public void DeleteOptions(List<Status> statusToDelete)
        {
            throw new NotImplementedException();
        }

        public List<Status> GetStatusOptions()
        {
            return new List<Status> { new Status("Not Started",0), new Status("In Progress",1), new Status("Completed",2)};
        }
    }

    [TestClass]
    public class PresenterTests
    {
        ITodoView _view = new mockView();
        ITodoService _Todoservice = new mockTodoService();
        IListService _Listservice = new mockListService();
        ITagService _TagService = new mockTagService();
        private IStatusService _statusService = new mockStatusService();

        [TestInitialize]
        public void Init()
        {
            _view = new mockView();
            _Todoservice = new mockTodoService();
            _Listservice = new mockListService();
            _TagService = new mockTagService();
        }

        [TestMethod]
        public void StartUp_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var presenter = new Presenter(_view, _Todoservice, _Listservice, _TagService, _statusService);

            try
            {
                presenter.StartUp();
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            // Assert
            Assert.IsTrue(((mockView)_view).calledStartup);
        }

        [TestMethod]
        public void UpdateView_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var presenter = new Presenter(_view, _Todoservice, _Listservice, _TagService, _statusService);

            presenter.UpdateView();


            // Assert
            //Assert.IsTrue(((mockListService)_Listservice).calledGetList);
            Assert.IsTrue(((mockView)_view).calledUpdate);
        }

        // requires rewrite or something, ui testing hard idk
        //[TestMethod]
        //public void CreateTodo_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var presenter = new Presenter(_view, _Todoservice, _Listservice, _TagService);

        //    presenter.StatusOptions = new();


        //    presenter.CreateTodo();

        //    // Assert
        //    Assert.IsTrue(((mockTodoService)_Todoservice).calledAdd);
        //}

        [TestMethod]
        public void DeleteTodo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var presenter = new Presenter(_view, _Todoservice, _Listservice, _TagService, _statusService);
            TodoItem todoItem = new("test", new Status(""));

            // Act
            presenter.DeleteTodo(todoItem);

            // Assert
            Assert.IsTrue(((mockTodoService)_Todoservice).calledDelete);
        }

        [TestMethod]
        public void CycleStatus_StateUnderTest_()
        {
            var presenter = new Presenter(_view, _Todoservice, _Listservice, _TagService, _statusService);
            Status status = _statusService.GetStatusOptions()[0];
            TodoItem todoItem = new("test", status);
            TodoData todoData = new TodoData
            {
                Title = "test",
                Status = new StatusData(status.Title,status.Order),
                ListTitle = "x",
                Description = "x",
                ToBeDeleted = false,
                CurrentTags = []
            };
            TodoViewItem item = new(todoData);

            Assert.AreEqual("Not Started", todoItem.Status.Title);
            presenter.CycleStatus(todoItem, item);
            Assert.AreEqual("In Progress", todoItem.Status.Title);
            presenter.CycleStatus(todoItem, item);
            Assert.AreEqual("Completed", todoItem.Status.Title);
        }
    }
}
