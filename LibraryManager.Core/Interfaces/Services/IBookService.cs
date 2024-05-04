using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Interfaces.Services {
    public interface IBookService {
        Task Add(Book book);
        Task Update(int id, Book book);
        Task Delete(int id);
        Task<Book> GetById(int id);
        Task<IEnumerable<Book>> GetAll();
    }
}
