using System.Diagnostics.CodeAnalysis;
using Todo.model.Services;
using Todo.view;

namespace Todo.presenter
{
    public class Program
    {
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            TodoView view = new();
            TodoService service = new TodoService();
            Presenter presenter = new(view, service);
            presenter.StartUp();
        }
    }
}

