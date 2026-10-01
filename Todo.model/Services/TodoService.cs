using System;
using System.Collections.Generic;
using System.Text;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Repositories;

namespace Todo.model.Services
{
    public class TodoService : ITodoService
    {
        private ITodoRepository _repository;
        private readonly List<TodoList> _todoLists = new List<TodoList>();
        public IReadOnlyList<TodoList> TodoLists => _todoLists;


        public TodoService()
        {
            _repository = new TodoRepository();
        }

        /// <summary>
        /// Adds the TodoItem to the TodoList with the given ID. Creates a new TodoList if none exist. Throws an IndexOutOfRange exception if ID doesnt exist.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="todoItem">The TodoItem.</param>
        public void Add(int listId, TodoItem todoItem)
        {
            //default behavior in case no lists exist
            if (_todoLists.Count == 0)
                _todoLists.Add(new TodoList());

            if (listId >= _todoLists.Count)
                throw new IndexOutOfRangeException();

            _repository.AddTodoItem(todoItem);
            _todoLists[listId].Add(todoItem);
        }

        /// <summary>
        /// Deletes the TodoItem from the TodoList with the given ID. Throws an IndexOutOfRange exception if ID doesnt exist.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="todoItem">The TodoItem.</param>
        public void Delete(int listId, TodoItem todoItem)
        {
            if (listId >= _todoLists.Count)
                throw new IndexOutOfRangeException();

            _repository.DeleteTodoItem(todoItem);
            _todoLists[listId].Remove(todoItem);
        }

        /// <summary>
        /// Gets the todo list with the given ID. Throws an IndexOutOfRange exception if ID doesnt exist.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <returns>The TodoList.</returns>
        public TodoList GetTodoList(int listId)
        {
            if(listId >= _todoLists.Count)
                throw new IndexOutOfRangeException();

            TodoList list = _repository.GetList(listId);

            return _todoLists[listId];
        }
    }
}
