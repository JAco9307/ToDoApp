using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Todo.model.Entities
{
    public class TodoList
    {
        private List<TodoItem> _items = new List<TodoItem>();

        public void Add(TodoItem item)
        {
            _items.Add(item);
        }

        public void Remove(TodoItem item)
        {
            //TodoItem? ListItem = _items.FirstOrDefault(_item => _item.Id == item.Id);

            //if(ListItem == null)
            //    throw new KeyNotFoundException("Given item was not found in the list");

            _items.Remove(item);
        }
    }
}
