using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Todo.view;
using Todo.view.Entities;

namespace Todo.testing.View
{

    [TestClass]
    public class EditTodoFormTests
    {
        private ContextData options = new ContextData
        {
            StatusOptions = ["Not Started",
                    "In Progress",
                    "Completed"],
            ListNames = ["New List"],
            AllTags = new(),
        };

        private TodoData TestTodoData = new TodoData
        {
            Title = "Title",
            Status = "Completed",
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
