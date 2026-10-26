using System.Diagnostics.CodeAnalysis;
using Todo.utility.Interfaces;
using Todo.view;
using Todo.WebView;

namespace Todo.presenter
{
    public class Program
    {
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            ITodoView view = new TodoWebView();
            Presenter presenter = new(view);
            presenter.StartUp();
            Console.ReadLine();
        }
    }
}

