using Todo.model.Entities;

namespace Todo.model.Interfaces;

public interface IStatusService
{
    /// <summary>
    /// Adds a list of status
    /// </summary>
    /// <param name="statusToAdd">The list of status to add</param>
    public void AddOptions(List<Status> statusToAdd);
    /// <summary>
    /// Deletes a list of status
    /// </summary>
    /// <param name="statusToDelete">The list of status to delete</param>
    public void DeleteOptions(List<Status> statusToDelete);
    /// <summary>
    /// Gets the status options.
    /// </summary>
    /// <returns>The status list result.</returns>
    public List<Status> GetStatusOptions();
}