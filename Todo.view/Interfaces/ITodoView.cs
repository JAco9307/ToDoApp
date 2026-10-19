using Todo.view.Entities;
using Todo.view.ViewObjects;

namespace Todo.view.Interfaces
{
    public interface ITodoView
    {

        /// <summary>
        /// Updates the active view list.
        /// </summary>
        /// <param name="todoTitles">The todo list.</param>
        /// <returns>List of each created todo view item </returns>
        public List<TodoViewItem> UpdateActiveViewList(List<TodoData> todoDatas);

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
        public TodoData ShowEditTodoDialog(ContextData context, TodoData currentData, bool IsNew);

        public TodoOptions ShowOptionsMenu(TodoOptions currentOptions);

        public void UpdateLists(List<string> lists, string selectList);

    }
}
