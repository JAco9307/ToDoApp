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

        [TestMethod]
        public void UpdateActiveViewList_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var todoView = new TodoView();
            List<string> todoTitles = ["Test","test2"];

            // Act
            var result = todoView.UpdateActiveViewList(
                todoTitles);

            // Assert
            Assert.IsNotEmpty(result);
            // not sure how to validate beyond that without making stuff public 
        }
    }
}
