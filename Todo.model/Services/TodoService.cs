using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Repositories;

namespace Todo.model.Services
{
    public class TodoService : ITodoService
    {
        private ITodoRepository _repository;
        private StatusList? _statusOptions;

        [ExcludeFromCodeCoverage]
        public TodoService()
        {
            _repository = new TodoRepository();
        }

        public TodoService(ITodoRepository todoRepository)
        {
            _repository = todoRepository;
        }

        //interface
        public void Add(TodoItem todoItem)
        {
            _repository.AddTodoItem(todoItem);
        }

        //interface
        public void Delete(TodoItem todoItem)
        {
            _repository.DeleteTodoItem(todoItem);
        }

        //interface
        public void UpdateDb()
        {
            _repository.UpdateDb();
        }

        //interface
        public StatusList GetStatusOptions()
        {
            if (_statusOptions == null)
            {
                StatusList? list = _repository.GetStatusOptions();
                _statusOptions = list ?? new StatusList();
            }
            return _statusOptions;
        }
    }
}
