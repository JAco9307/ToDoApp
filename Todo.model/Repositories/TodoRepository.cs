using System;
using System.Collections.Generic;
using System.Text;
using Todo.model.Data;
using Todo.model.Entities;
using Todo.model.Interfaces;

namespace Todo.model.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private TodoDbContext _dbContext = TodoDbContextFactory.Create();
        
        public void AddTodoItem(TodoItem item)
        {
            _dbContext.TodoItems.Add(item);
            _dbContext.SaveChanges();
        }

        public void DeleteTodoItem(TodoItem todoItem)
        {
            _dbContext.TodoItems.Remove(todoItem);
            _dbContext.SaveChanges();
        }

        public TodoList GetList(int TodoListId)
        {
            return _dbContext.TodoLists.Find(TodoListId);
        }
    }
}
