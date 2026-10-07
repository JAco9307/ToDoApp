using Microsoft.EntityFrameworkCore;
using Todo.model.Entities;

namespace Todo.model.Data;

public class TodoDbContext : DbContext
{

    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<TodoList> TodoLists { get; set; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="TodoDbContext"/> class
    /// </summary>
    /// <param name="options">DbContext Options</param>
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
        
    }

    /// <summary>
    /// Sets the constraints and relations for the database
    /// </summary>
    /// <param name="modelBuilder">The ModelBuilder.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Specifies primary key of TodoList
        modelBuilder.Entity<TodoList>().HasKey(todoList => todoList.Id);
        //Specifies one-to-many relationship between TodoList and TodoItem
        modelBuilder.Entity<TodoList>().HasMany(todoList => todoList.Items).WithOne().HasForeignKey(todoItem => todoItem.ListId).IsRequired();
    }
}