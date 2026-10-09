using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Todo.view;

namespace Todo.testing.View
{
    [TestClass]
    public class TodoViewTests
    {
        [TestMethod]
        public void StartUp_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var todoView = new TodoView();

            // Act
            var result = todoView.StartUp();

            // Assert
            Assert.IsExactInstanceOfType(result[0],typeof(Button));
            Assert.AreEqual("New Todo", result[0].Text);
        }
    }
}
