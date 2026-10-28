using Todo.model.Entities;
using Todo.view;
using Todo.view.Entities;

namespace Todo.testing.View
{

    [TestClass]
    public class EditTodoFormTests
    {
        private static StatusData NotStarted = new StatusData("Not Started", 0);
        private static StatusData InProgress = new StatusData("Not Started", 0);
        private static StatusData Completed = new StatusData("Not Started", 0);
        private ContextData options = new ContextData
        {
            StatusOptions = [NotStarted,
                    InProgress,
                   Completed],
            ListNames = ["New List"],
            AllTags = new(),
        };

        private TodoData TestTodoData = new TodoData
        {
            Title = "Title",
            Status = Completed,
            CurrentTags = new()
        };

        [TestMethod]
        public void cancelClick_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var editTodoForm = new EditTodoForm(options, TestTodoData);
            object sender = new();
            EventArgs e = new();

            // Act
            editTodoForm.CancelButton?.PerformClick();

            // Assert

            Assert.IsNull(editTodoForm.todoData.Title);
        }

        [TestMethod]
        public void saveClick_StateUnderTest_ExpectedBehavior()
        {
            var editTodoForm = new EditTodoForm(options, TestTodoData);
            object sender = new();
            EventArgs e = new();

            // Act
            editTodoForm.saveClick(sender, e);

            // Assert
            Assert.AreEqual("Title", editTodoForm.todoData.Title);
        }
    }
}
