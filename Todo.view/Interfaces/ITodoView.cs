using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.view.Interfaces
{
    public interface ITodoView
    {

        /// <summary>
        /// Updates the active view list.
        /// </summary>
        /// <param name="todoList">The todo list.</param>
        /// <returns>List of each created delete button.</returns>
        public List<Control> UpdateActiveViewList(object todoList);

        /// <summary>
        /// Start the form in a thread.
        /// </summary>
        /// <returns>Returns relevant controls for binding</returns>
        public List<Control> StartUp();

    }
}
