using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;

namespace LibraryManager.Application.Services; 
public class BookService(IBookRepository repository) : IBookService {

    private readonly IBookRepository _repository = repository;

    public async Task Add(Book book) {
        await _repository.Add(book);
    }
    public async Task Update(int id, Book book) {
        await _repository.Update(id, book);
    }

    public async Task Delete(int id) {
        await _repository.Delete(id);
    }

    public async Task<Book> GetById(int id) {
        return await _repository.GetById(id);
    }

    public async Task<IEnumerable<Book>> GetAll() {
        return await _repository.GetAll();
    }
}
