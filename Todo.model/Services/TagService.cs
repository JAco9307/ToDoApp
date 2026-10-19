using System;
using System.Collections.Generic;
using System.Text;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Repositories;

namespace Todo.model.Services
{
    public class TagService : ITagService
    {
        private ITodoRepository _repository;

        public TagService()
        {
            _repository = new TodoRepository();
        }
        public TagService(ITodoRepository todoRepository)
        {
            _repository = todoRepository;
        }


        //interface
        public List<TodoTag> GetAll()
        {
            return _repository.GetAllTags() ?? new List<TodoTag>();
        }

        //interface
        public void AddOptions(List<TodoTag> newTags)
        {
            _repository.AddTagOptions(newTags);
        }

        //interface
        public void RemoveOptions(List<TodoTag> newTags)
        {
            _repository.RemoveTagOptions(newTags);
        }
    }
}
