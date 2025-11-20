using APIforPostMVC.Models;

namespace APIforPostMVC.Data.Service;

public interface ITasksService
{
    Task<IEnumerable<Tasks>> GetAll();
    Task Add(Tasks task);
}
