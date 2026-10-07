using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Todo.model.Data;
using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Migrations;

namespace Todo.model.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private TodoDbContext _dbContext;
        private readonly List<string> default_status = [ 
            "Not Started",
            "In Progress",
            "Completed"
            ];

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
                todoList = new TodoList();
                _dbContext.TodoLists.Add(todoList);
                _dbContext.SaveChanges();
            }
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
            return _dbContext.TodoLists
                .Include(list => list.Items)
                .FirstOrDefault(list => list.Id == TodoListId);
        }

        public StatusList? GetStatusOptions()
        {
            return _dbContext.TodoStatusOptions
                .FirstOrDefault();
        }
    }
}
