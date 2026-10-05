using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics.CodeAnalysis;

namespace Todo.model.Data;

public class TodoDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
{
    [ExcludeFromCodeCoverage]
    public static TodoDbContext Create()
    {
        DbContextOptions<TodoDbContext> options = new DbContextOptionsBuilder<TodoDbContext>()
            .UseSqlite("Data Source=todo.sqlite")
            .Options;
        return new TodoDbContext(options);
    }

    [ExcludeFromCodeCoverage]
    public TodoDbContext CreateDbContext(string[] args)
    {
        return Create();
    }
}
