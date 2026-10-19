using Todo.view.Entities;
using Todo.view.ViewObjects;

namespace Todo.view.Interfaces
{
    public interface ITodoView
    {

        /// <summary>
        /// Updates the active view list.
        /// </summary>
        /// <param name="todoDatas">List of todoData to used to generate TodoViewItems</param>
        /// <returns>List of each created todo view item </returns>
        public List<TodoViewItem> UpdateActiveViewList(List<TodoData> todoDatas);

        /// <summary>
        /// Start the form in a thread.
        /// </summary>
        /// <returns>Returns relevant controls for binding</returns>
        public List<Control> StartUp();

        /// <summary>
        /// Shows an dialog window to create or edit a TodoItem
        /// </summary>
        /// <param name="context">The context data</param>
        /// <param name="currentData">The current todo data if applicable</param>
        /// <returns>The dialog input value.</returns>
        public TodoData ShowEditTodoDialog(ContextData context, TodoData currentData, bool IsNew);

        /// <summary>
        /// Opens the options form and recieves the data in it afterwards.
        /// </summary>
        /// <param name="currentOptions">The current options.</param>
        /// <returns>The options set when saving.</returns>
        public TodoOptions ShowOptionsMenu(TodoOptions currentOptions);

        /// <summary>
        /// Updates the lists in the header combobox.
        /// </summary>
        /// <param name="lists">The list titles.</param>
        /// <param name="selectList">The title of select list.</param>
        public void UpdateComboboxLists(List<string> lists, string selectList);

    }
}
