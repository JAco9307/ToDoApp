using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Repositories;

namespace Todo.model.Services
{
    public class TagService : ITagService
    {
        private ITodoRepository _repository;
        private List<TodoTag>? _allTags;

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
            if (_allTags != null)
                return _allTags;

            _allTags = _repository.GetAllTags() ?? new List<TodoTag>();
            return _allTags;
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
