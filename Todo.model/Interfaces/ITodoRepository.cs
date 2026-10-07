using System;
using System.Collections.Generic;
using System.Text;
using Todo.model.Entities;

namespace Todo.model.Interfaces
{
    public interface ITodoRepository
    {
        public TodoList? GetList(int TodoListId);
        public void AddTodoItem(TodoItem todoItem);
        public void DeleteTodoItem(TodoItem todoItem);
        public StatusList? GetStatusOptions();
    }
}
