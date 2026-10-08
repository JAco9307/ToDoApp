using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics.CodeAnalysis;

namespace Todo.model.Data;

public class TodoDbContextFactory : IDesignTimeDbContextFactory<TodoDbContext>
{
    /// <summary>
    /// Creates a TodoDbContext with default parameters
    /// </summary>
    /// <returns>A TodoDbContext</returns>
    [ExcludeFromCodeCoverage]
    public static TodoDbContext Create()
    {
        DbContextOptions<TodoDbContext> options = new DbContextOptionsBuilder<TodoDbContext>()
            .UseSqlite("Data Source=todo.sqlite")
            .Options;
        return new TodoDbContext(options);
    }

    /// <summary>
    /// Creates a TodoDbContext with default parameters as the arguments are not currently parsed
    /// </summary>
    /// <param name="args">String array of arguments</param>
    /// <returns>A TodoDbContext</returns>
    [ExcludeFromCodeCoverage]
    public TodoDbContext CreateDbContext(string[] args)
    {
        return Create();
    }
}
