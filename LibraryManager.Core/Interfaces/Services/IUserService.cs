using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Interfaces.Services; 
public interface IUserService {
    Task Add(User user);
    Task Update(int id, User user);
    Task Delete(int id);
    Task<User> GetById(int id);
    Task<IEnumerable<User>> GetAll();
}
