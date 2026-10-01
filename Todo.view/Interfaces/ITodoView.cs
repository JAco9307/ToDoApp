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
        /// <param name="todoTitles">The todo list.</param>
        /// <returns>List of each created todo view item </returns>
        public List<TodoViewItem> UpdateActiveViewList(List<string> todoTitles);


        /// <summary>
        /// Start the form in a thread.
        /// </summary>
        /// <returns>Returns relevant controls for binding</returns>
        public List<Control> StartUp();

    }
}
