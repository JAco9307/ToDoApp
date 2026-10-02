using System.Diagnostics;
using System.Windows;
using Todo.view;
using Todo.view.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Todo.presenter
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (!(args.Length == 0)) return;
            TodoView view = new();
            Presenter presenter = new(view, null);
            presenter.StartUp();
        }
    }
}

   