using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Todo.model.Data;

public class TodoDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
{
    public static TodoDbContext Create()
    {
        DbContextOptions<TodoDbContext> options = new DbContextOptionsBuilder<TodoDbContext>()
            .UseSqlite("Data Source=todo.sqlite")
            .Options;
        return new TodoDbContext(options);
    }

    public TodoDbContext CreateDbContext(string[] args)
    {
        return Create();
    }
}
