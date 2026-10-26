using Todo.model.Entities;
using Todo.model.Interfaces;
using Todo.model.Repositories;

namespace Todo.model.Services;

public class StatusService : IStatusService
{
    private ITodoRepository _repository;

    public StatusService(ITodoRepository repository)
    {
        _repository = repository;
    }
    
    public void AddOptions(List<Status> statusToAdd)
    {
        _repository.AddStatusOptions(statusToAdd);
    }

    public void DeleteOptions(List<Status> statusToDelete)
    {
        _repository.DeleteStatusOptions(statusToDelete);
    }

    public List<Status> GetStatusOptions()
    {
        return _repository.GetStatusOptions();
    }
}