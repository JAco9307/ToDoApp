using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Migrations;
using Todo.model.Repositories;
using Todo.model.Serialization;

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
        public async void Add(TodoItem todoItem)
        {
            _repository.AddTodoItem(todoItem);
        }

        //interface
        public async void Delete(TodoItem todoItem)
        {
            _repository.DeleteTodoItem(todoItem);
        }

        //interface
        public async void UpdateDb()
        {
            _repository.UpdateDb();
        }

        //interface
        public async Task<StatusList> GetStatusOptions()
        {
            if (_statusOptions == null)
            {
                StatusList? list = await _repository.GetStatusOptions();
                _statusOptions = list ?? new StatusList();
            }
            return _statusOptions;
        }
    }
}
