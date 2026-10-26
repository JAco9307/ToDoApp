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
        public void Add(TodoItem todoItem);

        /// <summary>
        /// Deletes the TodoItem from the TodoList with the given ID. 
        /// Throws an IndexOutOfRange exception if ID doesnt exist.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="todoItem">The TodoItem.</param>
        public void Delete(TodoItem todoItem);

        /// <summary>
        /// Updates all entities in database
        /// </summary>
        public void UpdateDb();

        /// <summary>
        /// Gets the status options.
        /// </summary>
        /// <returns>The status list result.</returns>
        public Task<StatusList> GetStatusOptions();
    }
}
