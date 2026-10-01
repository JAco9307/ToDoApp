using System;
using System.Collections.Generic;
using System.Text;
using Todo.model.Entities;
using Todo.model.Interfaces;

namespace Todo.model.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public void Add(TodoItem item)
        {
            //throw new NotImplementedException();
        }

        public void Delete(int TodoListId)
        {
            //throw new NotImplementedException();
        }

        public List<TodoItem> GetList(int TodoListId)
        {
            //throw new NotImplementedException();
            return new List<TodoItem>();
        }
    }
}
