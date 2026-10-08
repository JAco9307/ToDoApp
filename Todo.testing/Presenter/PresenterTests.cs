using System.Windows.Forms;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.presenter;
using Todo.view;
using Todo.view.Entities;
using Todo.view.Interfaces;

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

        public StatusList GetStatusOptions()
        {
            throw new NotImplementedException();
        }

        public void UpdateStatusOptions(StatusList options)
        {
            throw new NotImplementedException();
        }
    }

    public class mockView : ITodoView
    {
        public bool calledStartup = false;
        public bool calledUpdate = false;

        public TodoData ShowEditTodoDialog(List<string> statusOptions, string currentTitle = "")
        {
            return new TodoData
            {
                title = "bazinga",
                dialogResult = DialogResult.OK
            };
        }

        public TodoOptions ShowOptionsMenu(TodoOptions currentOptions)
        {
            throw new NotImplementedException();
        }

        public List<Control> StartUp()
        {
            calledStartup = true;
            return new List<Control>();
        }


        public List<TodoViewItem> UpdateActiveViewList(List<string> todoTitles, List<string> todoStatus)
        {
            calledUpdate = true;
            return new List<TodoViewItem>();
        }
    }

    [TestClass]
    public class PresenterTests
    {
        ITodoView _view;
        ITodoService _service;

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
            presenter.statusOptions = new();

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
            presenter.statusOptions = new();


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
            presenter.statusOptions = new();

            // Act
            presenter.DeleteTodo(todoItem);

            // Assert
            Assert.IsTrue(((mockService)_service).calledDelete);
        }

        [TestMethod]
        public void CycleStatus_StateUnderTest_()
        {
            var presenter = new Presenter(_view, _service);
            presenter.statusOptions = new();
            TodoItem todoItem = new("test");
            TodoViewItem item = new("test","Not Started");

            Assert.AreEqual("Not Started", todoItem.Status);
            presenter.CycleStatus(todoItem, item);
            Assert.AreEqual("In Progress", todoItem.Status);
            presenter.CycleStatus(todoItem, item);
            Assert.AreEqual("Completed", todoItem.Status);
        }
    }
}
