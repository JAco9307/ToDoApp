using System.Diagnostics;
using System.Windows;
using Todo.formview;
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
            FormView view = new();
            Presenter presenter = new(view, null);
            presenter.StartUp();
        }
    }

    public class Presenter: Form
    {
        private ITodoView _view;
        private int _currentListId;
        public Presenter(ITodoView view, object? service)
        {
            _view = view;
            _currentListId = 0; // read from database
        }

        public void StartUp()
        {
            
            EventHandlerSetup(((FormView)_view));
            System.Windows.Forms.Application.Run(((FormView)_view));
        }

        /// <summary>
        /// Perform the event handler setup.
        /// </summary>
        /// <param name="main">The View object.</param>
        private void EventHandlerSetup(FormView main)
        {
            main.deleteTodoButton.Click += delegate { DeleteTodo("Delete"); };
            main.createTodoButton.Click += delegate { CreateTodo(); };
            // temp examples: 
            main.todoText.LostFocus += delegate { DeleteTodo(main.todoText.Text); };
            main.Disposed += delegate { DeleteTodo(main.todoText.Text); };
        }

        public void UpdateView()
        {

        }

        public void CreateTodo()
        {
            Console.WriteLine("Create");
        }
        public void DeleteTodo(string a = "hi")
        {
            Console.WriteLine(a);
        }

    }
}

   