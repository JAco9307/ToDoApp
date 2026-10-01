using System;
using System.Collections.Generic;
using System.Text;
using Todo.model.Entities;
using Todo.model.Interfaces;

namespace Todo.model.Services
{
    public class TodoService : ITodoService
    {
        private readonly List<TodoList> _todoLists = new List<TodoList>();
        public IReadOnlyList<TodoList> todoLists => todoLists;

        public TodoService()
        {

        }

        public void Add(int listId, TodoItem todoItem)
        {
            //default behavior in case no lists exist
            if (_todoLists.Count == 0)
                _todoLists.Add(new TodoList());

            //if(listId >= _todoLists.Count)
            //    throw new IndexOutOfRangeException();

            _todoLists[listId].Add(todoItem);
        }

        public void Delete(int listId, TodoItem todoItem)
        {
            _todoLists[listId].Remove(todoItem);
        }

        public TodoList GetTodoList(int listId)
        {
            if(listId >= _todoLists.Count)
                throw new IndexOutOfRangeException();
            return _todoLists[listId];
        }
    }
}
