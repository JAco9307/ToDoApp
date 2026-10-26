using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Repositories;

namespace Todo.model.Services
{
    public class ListService : IListService
    {
        private ITodoRepository _repository;
        private readonly List<TodoList> _todoLists = new List<TodoList>();
        public List<TodoList> todoLists() => _todoLists;
        public ListService()
        {
            _repository = new TodoRepository();
            //var lists = _repository.GetLists();
            //foreach (var list in lists.Result)
            //    _todoLists.Add(list);
        }
        public ListService(ITodoRepository repository)
        {
            _repository = repository;
            //var lists = _repository.GetLists();
            //foreach (var list in lists.Result)
            //    _todoLists.Add(list);
        }

        //interface
        public async Task<TodoList> Get(int listId)
        {
            TodoList? list = _todoLists.Find(list => list.Id == listId);
            if (list != null)
                return list;

            list = await _repository.GetList(listId) ?? new TodoList(listId);

            _todoLists.Add(list);
            return list;
        }
        public async Task<TodoList> Get(string listTitle)
        {
            TodoList? list = _todoLists.Find(list => list.Title == listTitle);
            if (list != null)
                return list;

            list = await _repository.GetList(listTitle) ?? new TodoList { Title = listTitle };

            _todoLists.Add(list);
            return list;
        }


        //interface
        public async void Add(string Title)
        {
            await _repository.AddList(Title);
        }

        //interface
        public async void Delete(string Title)
        {
            var list = _todoLists.FirstOrDefault(list => list.Title == Title);
            if (list == null) return;
            _todoLists.Remove(list);
            _repository.DeleteList(list);
        }

        //interface
        public async void Rename(string TitleOld, string TitleNew)
        {
            var list = _todoLists.FirstOrDefault(list => list.Title == TitleOld);
            if (list == null) return;
            list.Title = TitleNew;
        }

        //interface
        public async Task<List<string>> GetNames()
        {
            List<string> output = await _repository.GetListNames();
            if (output.Count == 0 && _todoLists.Count == 0)
            {
                await _repository.AddList("New List");
                output.Add("New List");

            }
            if (output.Count == 0 && _todoLists.Count != 0)
            {
                output.Add(_todoLists[0].Title);
            }
            return output;
        }
    }
}
