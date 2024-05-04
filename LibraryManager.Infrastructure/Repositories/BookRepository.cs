
using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Repositories;
public class BookRepository(AppDbContext dbContext) : IBookRepository {

    private readonly AppDbContext _dbContext = dbContext;

    public async Task Add(Book book) {
        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(int id, Book book) {
        var existingBook = await _dbContext.Books.FindAsync(id);

        if (existingBook != null) {
            _dbContext.Entry(existingBook).Property("Title").CurrentValue = book.Title;
            _dbContext.Entry(existingBook).Property("Author").CurrentValue = book.Author;
            _dbContext.Entry(existingBook).Property("PublishDate").CurrentValue = book.PublishDate;

            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task Delete(int id) {
        var book = await _dbContext.Books.FindAsync(id);

        if (book != null) {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<Book?> GetById(int id) {
        var book = await _dbContext.Books
            .FirstOrDefaultAsync(b => b.Id == id);

        return null;
    }

    public async Task<IEnumerable<Book>> GetAll() {
        var loans = await _dbContext.Books
            .ToListAsync();

        return loans;
    }

}
