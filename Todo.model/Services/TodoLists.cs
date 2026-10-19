using System;
using System.Collections.Generic;
using System.Text;
using Todo.model.Entities;
using Todo.model.Interfaces;

namespace Todo.model.Services
{
    class TodoLists : ITodoService.ILists
    {
        private ITodoRepository _repository;
        private readonly List<TodoList> _todoLists = new List<TodoList>();
        public List<TodoList> todoLists() => _todoLists;
        public TodoLists(ITodoRepository repository)
        {
            _repository = repository;
            var lists = _repository.GetLists();
            foreach (var list in lists)
                _todoLists.Add(list);
        }

        //interface
        public TodoList Get(int listId)
        {
            TodoList? list = _todoLists.Find(list => list.Id == listId);
            if (list != null)
                return list;

            list = _repository.GetList(listId) ?? new TodoList(listId);

            _todoLists.Add(list);
            return list;
        }
        public TodoList Get(string listTitle)
        {
            TodoList? list = _todoLists.Find(list => list.Title == listTitle);
            if (list != null)
                return list;

            list = _repository.GetList(listTitle) ?? new TodoList { Title = listTitle };

            _todoLists.Add(list);
            return list;
        }


        //interface
        public void Add(string Title)
        {
            _repository.AddList(Title);
        }

        //interface
        public void Delete(string Title)
        {
            var list = _todoLists.FirstOrDefault(list => list.Title == Title);
            if (list == null) return;
            _todoLists.Remove(list);
            _repository.DeleteList(list);
        }

        //interface
        public void Rename(string TitleOld, string TitleNew)
        {
            var list = _todoLists.FirstOrDefault(list => list.Title == TitleOld);
            if (list == null) return;
            list.Title = TitleNew;
        }

        //interface
        public List<string> GetNames()
        {
            _repository.UpdateDb();
            List<string> output = _repository.GetListNames();
            if (output.Count == 0 && _todoLists.Count == 0)
            {
                TodoList list = new TodoList(1);
                _todoLists.Add(list);
                output.Add(list.Title);

            }
            if (output.Count == 0 && _todoLists.Count != 0) //not sure why this check is nessesary but it is
            {
                output.Add(_todoLists[0].Title);
            }
            return output;
        }
    }
}
