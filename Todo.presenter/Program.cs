using System.Diagnostics.CodeAnalysis;
using Todo.model.Interfaces;
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
            Presenter presenter = new(view);
            presenter.StartUp();
        }
    }
}

