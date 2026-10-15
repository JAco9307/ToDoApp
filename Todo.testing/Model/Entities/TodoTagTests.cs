using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using Todo.model.Entities;

namespace Todo.testing;

[TestClass]
public class TodoTagTests
{
    [TestMethod]
    public void Init_StoresTitleAndColor()
    {
        TodoTag tag = new TodoTag("Title", Color.Green);

        Assert.AreEqual("Title", tag.Title);
        Assert.AreEqual(Color.Green, tag.Color);
    }
}
