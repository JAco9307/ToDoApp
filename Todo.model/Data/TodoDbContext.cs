using Microsoft.EntityFrameworkCore;
using Todo.model.Entities;

namespace Todo.model.Data;

public class TodoDbContext : DbContext
{

    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<TodoList> TodoLists { get; set; }
    

    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Specifies primary key of TodoList
        modelBuilder.Entity<TodoList>().HasKey(todoList => todoList.Id);
        //Specifies one-to-many relationship between TodoList and TodoItem
        modelBuilder.Entity<TodoList>().HasMany(todoList => todoList.Items).WithOne().HasForeignKey(todoItem => todoItem.ListId).IsRequired();
    }
}