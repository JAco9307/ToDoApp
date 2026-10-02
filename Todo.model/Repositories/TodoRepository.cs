using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Todo.model.Data;
using Todo.model.Entities;
using Todo.model.Interfaces;

namespace Todo.model.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private TodoDbContext _dbContext;

        [ExcludeFromCodeCoverage]
        public TodoRepository()
        {
            _dbContext = TodoDbContextFactory.Create();
        }

        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void AddTodoItem(TodoItem item)
        {
            TodoList? todoList = _dbContext.TodoLists.FirstOrDefault();
            if (todoList == null)
            {
                _dbContext.TodoLists.Add(new TodoList());
                _dbContext.SaveChanges();
                todoList = _dbContext.TodoLists.FirstOrDefault();
            }
            if (todoList == null)
                throw new NullReferenceException();

            item.ListId = todoList.Id;
            _dbContext.TodoItems.Add(item);
            _dbContext.SaveChanges();
        }

        public void DeleteTodoItem(TodoItem todoItem)
        {
            _dbContext.TodoItems.Remove(todoItem);
            _dbContext.SaveChanges();
        }

        public TodoList? GetList(int TodoListId)
        {


            return _dbContext.TodoLists.Find(TodoListId);
        }
    }
}
