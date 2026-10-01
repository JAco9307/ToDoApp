using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Todo.view.Interfaces;

namespace Todo.presenter
{
    public class Presenter : Form
    {
        private ITodoView _view;
        private int _currentListId;
        public Presenter(ITodoView view, object? service)
        {
            _view = view;
            _currentListId = 0;
        }

        public void StartUp()
        {
            List<Control> controls = _view.StartUp();
            EventHandlerSetup(controls);

        }

        /// <summary>
        /// Perform the event handler setup.
        /// </summary>
        /// <param name="main">The View object.</param>
        private void EventHandlerSetup(List<Control> controls)
        {
            controls[1].Click += delegate { DeleteTodo("Delete"); };
            controls[0].Click += delegate { CreateTodo(); };
            // temp examples: 
            controls[2].Disposed += delegate { DeleteTodo(controls[2].Text); };
            controls[2].LostFocus += delegate { DeleteTodo(controls[2].Text); };

        }

        public void UpdateView()
        {
            List<Control> deleteButtons = _view.UpdateActiveViewList(null);

            for (int i = 0; i < deleteButtons.Count; i++)
            {
                deleteButtons[i].Click += delegate { DeleteTodo("delete " + i); };
            }
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
