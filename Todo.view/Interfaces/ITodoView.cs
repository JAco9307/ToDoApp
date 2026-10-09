using System;
using System.Collections.Generic;
using System.Text;
using Todo.view.Entities;

namespace Todo.view.Interfaces
{
    public interface ITodoView
    {

        /// <summary>
        /// Updates the active view list.
        /// </summary>
        /// <param name="todoTitles">The todo list.</param>
        /// <returns>List of each created todo view item </returns>
        public List<TodoViewItem> UpdateActiveViewList(List<string> todoTitles, List<string> todoStatus);

        /// <summary>
        /// Start the form in a thread.
        /// </summary>
        /// <returns>Returns relevant controls for binding</returns>
        public List<Control> StartUp();

        /// <summary>
        /// Opens a popup prompt for creating todo.
        /// </summary>
        /// <param name="currentTitle">The current title of the todo.</param>
        /// <returns>The popup input value.</returns>
        public TodoData ShowEditTodoDialog(ContextData context, TodoData? currentData = null);

        public TodoOptions ShowOptionsMenu(TodoOptions currentOptions);
<<<<<<< HEAD

        public void UpdateLists(List<string> lists, string selectList);

=======
>>>>>>> main
    }
}
