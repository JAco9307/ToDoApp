using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        [ExcludeFromCodeCoverage]
        public TodoService()
        {
            _repository = new TodoRepository();
        }

        public TodoService(ITodoRepository todoRepository)
        {
            _repository = todoRepository;
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
        /// Gets the todo list with the given ID. If Id is out of range, then it check the Db, and then if still not found, then it creates a new.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <returns>The TodoList.</returns>
        public TodoList GetTodoList(int listId)
        {
            TodoList? list = _todoLists.FirstOrDefault(todoList => todoList.Id == listId);
            if (list != null)
                return list;

            list = _repository.GetList(listId);
            if(list != null)
            {
                _todoLists.Add(list);
                return list;
            }
            
            list = new TodoList(listId);
            _todoLists.Add(list);
            return list;
        }
    }
}
