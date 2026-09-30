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
            Presenter p = new(); 
        }
    }
    
    public class Presenter: Form
    {
        public Presenter() 
        {
            var main = new FormView();
            main.deleteTodoButton.Click += delegate { pprint("Delete"); };
            main.createTodoButton.Click += delegate { pprint("Create"); };
            main.todoText.LostFocus += delegate { pprint(main.todoText.Text); };
            main.Disposed += delegate { pprint(main.todoText.Text); };
            System.Windows.Forms.Application.Run(main);
        }

        public void pprint(string a = "hi")
        {
            Console.WriteLine(a);
        }
    }
}

   