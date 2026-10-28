namespace Todo.model.Entities;

public class Status
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Order { get; set; }

    public Status(string title)
    {
        Title = title;
    }

    public Status(string title, int order)
    {
        Title = title;
        Order = order;
    }
    public override string ToString()
    {
        return Title;
    }
}