using Todo.model.Entities;

namespace Todo.model.Interfaces;

public interface IStatusService
{
    public void AddOptions(List<Status> statusToAdd);
    public void DeleteOptions(List<Status> statusToDelete);
    public List<Status> GetStatusOptions();
}