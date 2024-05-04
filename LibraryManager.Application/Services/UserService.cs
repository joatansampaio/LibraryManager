using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;

namespace LibraryManager.Application.Services; 
public class UserService(IUserRepository repository) : IUserService {
    private readonly IUserRepository _repository = repository;

    public async Task Add(User user) {
        await _repository.Add(user);
    }

    public async Task Update(int id, User user) {
        await _repository.Update(id, user);
    }

    public async Task Delete(int id) {
        await _repository.Delete(id);
    }

    public async Task<User> GetById(int id) {
        return await _repository.GetById(id);
    }

    public async Task<IEnumerable<User>> GetAll() {
        return await _repository.GetAll();
    }
}
