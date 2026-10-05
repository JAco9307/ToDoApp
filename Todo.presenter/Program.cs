using System.Diagnostics;
using System.Windows;
using Todo.view;
using Todo.model;
using Todo.view.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;
using Todo.model.Services;

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

   