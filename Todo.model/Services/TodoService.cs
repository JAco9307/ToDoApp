using System.Diagnostics.CodeAnalysis;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Repositories;

namespace Todo.model.Services
{
    public class TodoService : ITodoService
    {
        private ITodoRepository _repository;
        private readonly Dictionary<int, TodoList> _todoLists = new Dictionary<int, TodoList>();
        public IReadOnlyDictionary<int, TodoList> TodoLists => _todoLists;

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
            _repository.AddTodoItem(todoItem);
        }
        /// <summary>
        /// Updates a TodoItem with new values
        /// </summary>
        /// <param name="todoItem"></param>
        public void UpdateTodoItem(TodoItem todoItem)
        {
            _repository.UpdateTodoItem(todoItem);
        }

        /// <summary>
        /// Deletes the TodoItem from the TodoList with the given ID. Throws an IndexOutOfRange exception if ID doesnt exist.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <param name="todoItem">The TodoItem.</param>
        public void Delete(int listId, TodoItem todoItem)
        {
            _repository.DeleteTodoItem(todoItem);
        }

        /// <summary>
        /// Gets the todo list with the given ID. If Id is out of range, then it check the Db, and then if still not found, then it creates a new.
        /// </summary>
        /// <param name="listId">The list id.</param>
        /// <returns>The TodoList.</returns>
        public TodoList GetTodoList(int listId)
        {
            if(_todoLists.ContainsKey(listId))
                return _todoLists[listId];

            TodoList? list = _repository.GetList(listId);
            if(list != null)
            {
                _todoLists.Add(listId, list);
                return list;
            }
            
            list = new TodoList(listId);
            _todoLists.Add(listId, list);
            return list;
        }
    }
}
