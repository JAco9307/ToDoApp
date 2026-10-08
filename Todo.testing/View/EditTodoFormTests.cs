using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Todo.view;

namespace Todo.testing.View
{

    [TestClass]
    public class EditTodoFormTests
    {
        private List<string> options = ["Not Started",
                    "In Progress",
                    "Completed"];
        [TestMethod]
        public void cancelClick_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var editTodoForm = new EditTodoForm(options,"a");
            object sender = new();
            EventArgs e = new();

            // Act
            editTodoForm.cancelClick(sender, e);

            // Assert
            Assert.AreEqual(DialogResult.Cancel, editTodoForm.DialogResult);
            Assert.AreEqual("a", editTodoForm.Titlestr);
        }

        [TestMethod]
        public void saveClick_StateUnderTest_ExpectedBehavior()
        {
            var editTodoForm = new EditTodoForm(options, "a");
            object sender = new();
            EventArgs e = new();

            // Act
            editTodoForm.saveClick(sender, e);

            // Assert
            Assert.AreEqual(DialogResult.OK, editTodoForm.DialogResult);
            Assert.AreEqual("a", editTodoForm.Titlestr);
        }
    }
}
