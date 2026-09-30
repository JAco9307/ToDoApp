using System;
using System.Collections.Generic;
using System.Text;
using Todo.model.Entities;
using Todo.model.Interfaces;

namespace Todo.model.Services
{
    public class TodoService : ITodoService
    {
        private I
        private readonly List<TodoList> _todoLists;
        public IReadOnlyList<TodoList> todoLists { get; private set; }



        public TodoService()
        {

        }
        public void Add(int listId, TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(int listId, TodoItem todoItem)
        {
            throw new NotImplementedException();
        }

        public TodoList GetTodoList(int listId)
        {
            throw new NotImplementedException();
        }
    }
}
