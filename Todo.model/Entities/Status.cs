namespace Todo.model.Entities;

public class Status
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Order { get; set; }
    public List<TodoItem> TodoItems { get; set; }

    public Status(string title)
    {
        Title = title;
    }
    public override string ToString()
    {
        return Title;
    }
}