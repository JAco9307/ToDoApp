using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Todo.model.Entities
{
    public class TodoList
    {
        public int Id { get; private set; }
        private readonly List<TodoItem> _items = new List<TodoItem>();
        public IReadOnlyList<TodoItem> Items => _items;

        /// <summary>
        /// Adds the TodoItem to the TodoList.
        /// </summary>
        /// <param name="item">The TodoItem.</param>
        public void Add(TodoItem item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Removes the TodoItem to the TodoList. Throws KeyNotFoundException if removing fails.
        /// </summary>
        /// <param name="item">The TodoItem.</param>
        public void Remove(TodoItem item)
        {
            //TodoItem? ListItem = _items.FirstOrDefault(_item => _item.Id == item.Id);

            //if(ListItem == null)
            //    throw new KeyNotFoundException("Given item was not found in the list");

            bool success = _items.Remove(item);

            if(!success)
                throw new KeyNotFoundException("Given item was not found in the list");
        }
    }
}
