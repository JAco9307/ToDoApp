using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Todo.model;
using Todo.model.Interfaces;
using Todo.presenter;
using Todo.view;
using Todo.view.Interfaces;

namespace Todo.testing.Presenter
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

        public void Delete(int listId, TodoItem todoItem)
        {
            calledDelete = true;
        }

        public IReadOnlyList<TodoItem> GetTodoList(int listId)
        {
            calledGetList = true;
            return new List<TodoItem>();
        }
    }

    public class mockView : ITodoView
    {
        public bool calledStartup = false;
        public bool calledUpdate = false;

        public PopupResult GetPopupResult(string currentTitle = "")
        {
            return new PopupResult {
                title = "bazinga",
                dialogResult = DialogResult.OK
            };
        }

        public List<Control> StartUp()
        {
            calledStartup = true;
            return new List<Control>();
        }

        public List<TodoViewItem> UpdateActiveViewList(List<string> todoTitles)
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


            presenter.CreateTodo();

            // Assert
            Assert.IsTrue(((mockService)_service).calledAdd);
        }

        [TestMethod]
        public void DeleteTodo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var presenter = new Presenter(_view, _service);
            TodoItem todoItem = default;

            // Act
            presenter.DeleteTodo(todoItem);

            // Assert
            Assert.IsTrue(((mockService)_service).calledDelete);
        }
    }
}
