namespace Todo.view.Entities;

public struct StatusData
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Order { get; set; }

    public StatusData(int id, string title, int order)
    {
        Id = id;
        Title = title;
        Order = order;
    }

    public StatusData(string value)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return Title;
    }
}