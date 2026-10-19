using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface ITodoRepository
    {
        /// <summary>
        /// Adds a TodoItem to the database and saves it
        /// </summary>
        /// <param name="todoItem">The TodoItem to add</param>
        /// <param name="listId">The id of list to add the item to</param>
        public void AddTodoItem(TodoItem todoItem, int listId);

        /// <summary>
        /// Adds a new list.
        /// </summary>
        /// <param name="Title">The title of the new list.</param>
        /// <returns>The todo list result.</returns>
        public TodoList AddList(string Title);

        /// <summary>
        /// Deletes a list.
        /// </summary>
        /// <param name="list">The list.</param>
        public void DeleteList(TodoList list);

        /// <summary>
        /// Updates all entities with unsaved changes to the database
        /// </summary>
        public void UpdateDb();

        /// <summary>
        /// Gets a TodoList with a given Id, Creates a new list if none exist
        /// </summary>
        /// <param name="TodoListId">Id of the TodoList</param>
        /// <returns>The TodoList</returns>
        public TodoList? GetList(int TodoListId);

        /// <summary>
        /// Gets a TodoList with a given Title, Creates a new list if none exist
        /// </summary>
        /// <param name="TodoListTitle">Title of the TodoList</param>
        /// <returns>The TodoList</returns>
        public TodoList? GetList(string TodoListTitle);

        /// <summary>
        /// Gets all <see cref="TodoList"> titles as a list
        /// </summary>
        /// <returns>The todolist titles</returns>
        public List<string> GetListNames();

        /// <summary>
        /// Gets all <see cref="TodoList">s as a list
        /// </summary>
        /// <returns>The todolists/returns>
        public List<TodoList> GetLists();

        /// <summary>
        /// Gets the Status options, if none exists makes a new default entry.
        /// </summary>
        /// <returns>The Status list result.</returns>
        public StatusList? GetStatusOptions();

        /// <summary>
        /// Gets the all tags.
        /// </summary>
        /// <returns>The list result.</returns>
        public List<TodoTag>? GetAllTags();

        /// <summary>
        /// Adds new tag options.
        /// </summary>
        /// <param name="newTags">The new tags.</param>
        public void AddTagOptions(List<TodoTag> newTags);

        /// <summary>
        /// Removes tag options.
        /// </summary>
        /// <param name="tags">The tags to remove.</param>
        public void RemoveTagOptions(List<TodoTag> newTags);






    }
}
