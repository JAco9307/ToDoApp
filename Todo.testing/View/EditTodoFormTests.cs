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
        [TestMethod]
        public void cancelClick_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var editTodoForm = new EditTodoForm(new ContextData("a",new List<(string, System.Drawing.Color)>(), new List<(string, System.Drawing.Color)>()));
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
            var editTodoForm = new EditTodoForm(new ContextData("a", new List<(string, System.Drawing.Color)>(), new List<(string, System.Drawing.Color)>()));
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
