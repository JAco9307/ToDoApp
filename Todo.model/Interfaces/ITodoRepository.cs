using System;
using System.Collections.Generic;
using System.Text;
using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface ITodoRepository
    {
        public List<TodoItem> GetList(int TodoListId);
        public void Add(TodoItem item);
        public void Delete(int TodoListId);
    }
}
