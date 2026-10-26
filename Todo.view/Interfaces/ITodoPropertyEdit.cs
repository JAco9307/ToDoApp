using Todo.DTOs;

namespace Todo.view.Interfaces
{
    public interface ITodoPropertyEdit // maybe think of better name some time
    {
        /// <summary>
        /// Updates the Todo item data.
        /// </summary>
        /// <param name="data">The current todo item data.</param>
        /// <returns>The updated todo data.</returns>
        public TodoData UpdateData(TodoData data);

    }
}
