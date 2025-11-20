using APIforPostMVC.Models;

namespace APIforPostMVC.Data.Service;

public interface IProjectsService
{
    Task<IEnumerable<Projects>> GetAll();
    Task Add(Projects project);


}
