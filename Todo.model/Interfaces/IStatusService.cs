using Todo.model.Entities;

namespace Todo.model.Interfaces;

public interface IStatusService
{
    public void AddOptions(List<Status> statusToAdd);
    public void DeleteOptions(List<Status> statusToDelete);
    /// <summary>
    /// Gets the status options.
    /// </summary>
    /// <returns>The status list result.</returns>
    public List<Status> GetStatusOptions();
}