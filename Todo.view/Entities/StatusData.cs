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

    public StatusData(string title, int order)
    {
        Title = title;
        Order = order;
    }

    public override string ToString()
    {
        return Title;
    }
    
    public static int CompareByStatus(StatusData item1, StatusData item2)
    {
        return item1.Order - item2.Order;
    }
}