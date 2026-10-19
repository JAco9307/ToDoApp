using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface ITodoService
    {
        /// <summary>
        /// Adds the TodoItem to the TodoList with the given ID. 
        /// Creates a new TodoList if none exist. 
        /// Throws an IndexOutOfRange exception if ID doesnt exist.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="todoItem">The TodoItem.</param>
        public void Add(int listId, TodoItem todoItem);

        /// <summary>
        /// Updates all entities in database
        /// </summary>
        public void UpdateDb();

        /// <summary>
        /// Deletes the TodoItem from the TodoList with the given ID. 
        /// Throws an IndexOutOfRange exception if ID doesnt exist.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="todoItem">The TodoItem.</param>
        public void Delete(int listId, TodoItem todoItem);

        /// <summary>
        /// Gets the todo list with the given ID,
        /// If list is not found in service layer it checks database,
        /// If not found in database it creates a new list.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <returns>The TodoList.</returns>
        public TodoList GetTodoList(int listId);

        /// <summary>
        /// Gets the todo list with the given Title,
        /// If list is not found in service layer it checks database,
        /// If not found in database it creates a new list.
        /// </summary>
        /// <param name="listTitle">The list title.</param>
        /// <returns>The TodoList.</returns>
        public TodoList GetTodoList(string listTitle);

        /// <summary>
        /// Adds a new list to the repository.
        /// </summary>
        /// <param name="Title">The list's title.</param>
        public void AddList(string Title);

        /// <summary>
        /// Deletes a list.
        /// </summary>
        /// <param name="Title">The title.</param>
        public void DeleteList(string Title);

        /// <summary>
        /// Renames a list by name.
        /// </summary>
        /// <param name="TitleOld">The current title .</param>
        /// <param name="TitleNew">The new title .</param>
        public void RenameList(string TitleOld, string TitleNew);

        /// <summary>
        /// Gets the status options.
        /// </summary>
        /// <returns>The status list result.</returns>
        public StatusList GetStatusOptions();

        /// <summary>
        /// Gets the list names. If no lists are found, creates a new empty list
        /// </summary>
        /// <returns>The list result.</returns>
        public List<string> GetListNames();

        /// <summary>
        /// Gets the all tags.
        /// </summary>
        /// <returns>The list result.</returns>
        public List<TodoTag> GetAllTags();


        /// <summary>
        /// Adds the given tag options.
        /// </summary>
        /// <param name="newTags">The new tags.</param>
        public void AddTagOptions(List<TodoTag> newTags);

        /// <summary>
        /// Removes the given tag options.
        /// </summary>
        /// <param name="newTags">The tags to remove.</param>
        public void RemoveTagOptions(List<TodoTag> newTags);

    }
}
