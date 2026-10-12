using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Todo.view;
using Todo.view.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Todo.testing.View
{
    [TestClass]
    public class OptionsFormTests
    {
        [TestMethod]
        public void cancelClick_StateUnderTest_ExpectedBehavior()
        {
            TodoOptions ops = new TodoOptions();
            ops.Status = [ "a", "b" ];
            OptionsForm optionsForm = new OptionsForm(ops);
            object sender = new();
            EventArgs e = new();

            // Act
            optionsForm.cancelClick(sender, e);

            // Assert
            Assert.AreEqual(DialogResult.Cancel, optionsForm.DialogResult);
            Assert.AreEqual(ops, optionsForm.OutputOptions);
        }

        [TestMethod]
        public void saveClick_StateUnderTest_ExpectedBehavior()
        {
            TodoOptions ops = new TodoOptions();
            ops.Status = ["a", "b"];
            OptionsForm optionsForm = new OptionsForm(ops);
            object sender = new();
            EventArgs e = new();

            optionsForm.statusTextBox.Text = "c,d";
            optionsForm.saveClick(sender, e);

            // Assert
            Assert.AreEqual(DialogResult.OK, optionsForm.DialogResult);
            Assert.AreSequenceEqual(["c", "d"], optionsForm.OutputOptions.Status);
        }
    }
}
