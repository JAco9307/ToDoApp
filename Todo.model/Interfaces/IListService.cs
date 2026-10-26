using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface IListService
    {
        public List<TodoList> todoLists();
        /// <summary>
        /// Gets the todo list with the given ID,
        /// If list is not found in service layer it checks database,
        /// If not found in database it creates a new list.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <returns>The TodoList.</returns>
        public Task<TodoList> Get(int listId);

        /// <summary>
        /// Gets the todo list with the given Title,
        /// If list is not found in service layer it checks database,
        /// If not found in database it creates a new list.
        /// </summary>
        /// <param name="listTitle">The list title.</param>
        /// <returns>The TodoList.</returns>
        public Task<TodoList> Get(string listTitle);

        /// <summary>
        /// Adds a new list to the repository.
        /// </summary>
        /// <param name="Title">The list's title.</param>
        public void Add(string Title);

        /// <summary>
        /// Deletes a list.
        /// </summary>
        /// <param name="Title">The title.</param>
        public void Delete(string Title);

        /// <summary>
        /// Renames a list by name.
        /// </summary>
        /// <param name="TitleOld">The current title .</param>
        /// <param name="TitleNew">The new title .</param>
        public void Rename(string TitleOld, string TitleNew);

        /// <summary>
        /// Gets the list names. If no lists are found, creates a new empty list
        /// </summary>
        /// <returns>The list result.</returns>
        public Task<List<string>> GetNames();
    }
}
