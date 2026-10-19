using System.Windows.Forms;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.presenter;
using Todo.view;
using Todo.view.Entities;
using Todo.view.Interfaces;
using Todo.view.ViewObjects;

namespace Todo.testing.presenter
{
    public class mockService : ITodoService
    {

        public bool calledAdd = false;
        public bool calledDelete = false;
        public bool calledGetList = false;
        public void Add(int listId, TodoItem todoItem)
        {
            calledAdd = true;
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
        }

        public void Delete(int listId, TodoItem todoItem)
        {
            calledDelete = true;
        }

        public TodoList GetTodoList(int listId)
        {
            calledGetList = true;
            return new TodoList();
        }
        public List<TodoTag> GetAllTags()
        {
            return [];
        }
        public StatusList GetStatusOptions()
        {
            throw new NotImplementedException();
        }
        public void UpdateStatusOptions(StatusList options)
        {
            throw new NotImplementedException();
        }
        public void UpdateDb()
        {
            
        }
        public void AddList(string Title)
        {
            throw new NotImplementedException();
        }
        public void UpdateTagOptions(List<TodoTag> tags)

        {
            throw new NotImplementedException();
        }
        public void DeleteList(string Title)
        {
            throw new NotImplementedException();
        }
        public void AddTagOptions(List<TodoTag> newTags)
        {
            throw new NotImplementedException();
        }
        public void RenameList(string TitleOld, string TitleNew)
        {
            throw new NotImplementedException();
        }
        public List<string> GetListNames()
        {
            return [];
        }
        public TodoList GetTodoList(string listId)
        {
            return new();

        }
        public void RemoveTagOptions(List<TodoTag> newTags)
        {
            throw new NotImplementedException();
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

        public void UpdateLists(List<string> lists, string selectList)
        {
            throw new NotImplementedException();
        }
    }

    [TestClass]
    public class PresenterTests
    {
        ITodoView _view = new mockView();
        ITodoService _service = new mockService();

        [TestInitialize]
        public void Init() 
        {
            _view = new mockView();
            _service = new mockService();
        }

        [TestMethod]
        public void StartUp_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var presenter = new Presenter(_view, _service);

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
            var presenter = new Presenter(_view, _service);
            presenter.StatusOptions = new();

            presenter.UpdateView();


            // Assert
            Assert.IsTrue(((mockService)_service).calledGetList);
            Assert.IsTrue(((mockView)_view).calledUpdate);
        }

        [TestMethod]
        public void CreateTodo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var presenter = new Presenter(_view, _service);
            presenter.StatusOptions = new();


            presenter.CreateTodo();

            // Assert
            Assert.IsTrue(((mockService)_service).calledAdd);
        }

        [TestMethod]
        public void DeleteTodo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var presenter = new Presenter(_view, _service);
            TodoItem todoItem = new("test");
            presenter.StatusOptions = new();

            // Act
            presenter.DeleteTodo(todoItem);

            // Assert
            Assert.IsTrue(((mockService)_service).calledDelete);
        }

        [TestMethod]
        public void CycleStatus_StateUnderTest_()
        {
            var presenter = new Presenter(_view, _service);
            presenter.StatusOptions = new();
            TodoItem todoItem = new("test");
            TodoData todoData = new TodoData
            {
                Title = "test",
                Status = "Not Started",
                ListTitle = null,
                Description = null,
                ToBeDeleted = false,
                CurrentTags = null
            };
            TodoViewItem item = new(todoData);

            Assert.AreEqual("Not Started", todoItem.Status);
            presenter.CycleStatus(todoItem, item);
            Assert.AreEqual("In Progress", todoItem.Status);
            presenter.CycleStatus(todoItem, item);
            Assert.AreEqual("Completed", todoItem.Status);
        }
    }
}
