using System;
using System.Collections.Generic;
using System.Text;
using Todo.view.Entities;

namespace Todo.view.Interfaces
{
    public interface ITodoPropertyEdit
    {
        /// <summary>
        /// Updates the Todo item data.
        /// </summary>
        /// <param name="data">The current todo item data.</param>
        /// <returns>The updated todo data.</returns>
        public TodoData UpdateData(TodoData data);

    }
}
