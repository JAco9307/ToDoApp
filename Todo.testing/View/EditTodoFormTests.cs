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
                    "Completed"]
        };

        private TodoData TestTodoData = new TodoData 
        { 
            title = "Title",
            status = "Completed",
        };

        [TestMethod]
        public void cancelClick_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var editTodoForm = new EditTodoForm(options, TestTodoData);
            object sender = new();
            EventArgs e = new();

            // Act
            editTodoForm.cancelClick(sender, e);

            // Assert
            Assert.AreEqual(null, editTodoForm.Titlestr);
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
            Assert.AreEqual("Title", editTodoForm.Titlestr);
        }
    }
}
