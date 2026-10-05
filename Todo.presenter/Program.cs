using System.Diagnostics;
using System.Windows;
using Todo.view;
using Todo.view.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics.CodeAnalysis;

namespace Todo.presenter
{
    public class Program
    {
        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            TodoView view = new();
            Presenter presenter = new(view, null);
            presenter.StartUp();
        }
    }
}

   