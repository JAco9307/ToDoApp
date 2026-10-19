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
        public ITodoService.ILists Lists { get; }

        [ExcludeFromCodeCoverage]
        public TodoService()
        {
            _repository = new TodoRepository();
            Lists = new TodoLists(_repository);
        }

        public TodoService(ITodoRepository todoRepository)
        {
            _repository = todoRepository;
            Lists = new TodoLists(_repository);
        }

        //interface
        public void Add(int listId, TodoItem todoItem)
        {
            Lists.todoLists().Find(list => list.Id == listId)?.Add(todoItem);
            _repository.AddTodoItem(todoItem, listId);
        }

        //interface
        public void UpdateDb()
        {
            _repository.UpdateDb();
        }

        //interface
        public void Delete(int listId, TodoItem todoItem)
        {
            Lists.todoLists().First(list => list.Id == listId).Remove(todoItem);
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



        //interface
        public List<TodoTag> GetAllTags()
        {
            return _repository.GetAllTags() ?? new List<TodoTag>();
        }

        //interface
        public void AddTagOptions(List<TodoTag> newTags)
        {
            _repository.AddTagOptions(newTags);
        }

        //interface
        public void RemoveTagOptions(List<TodoTag> newTags)
        {
            _repository.RemoveTagOptions(newTags);
        }
    }
}
