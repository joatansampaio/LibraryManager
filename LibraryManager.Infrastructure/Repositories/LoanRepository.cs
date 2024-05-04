using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Models;
using LibraryManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Repositories;
public class LoanRepository(AppDbContext context) : ILoanRepository {

    private readonly AppDbContext _context = context;

    public async Task<bool> CheckOut(CreateLoanInputModel model) {
        var loan = new Loan {
            UserId = model.UserId,
            BookId = model.BookId,
        };
        loan.CheckOut();
        await _context.Loans.AddAsync(loan);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CheckIn(int id) {
        var loan = await _context.Loans.FindAsync(id);
        if (loan is null) return false;
        loan.CheckIn();
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Loan>> GetAll() {
        var loans = await _context.Loans
            .Include(l => l.User)
            .Include(l => l.Book)
            .AsNoTracking()
            .ToListAsync();
        return loans;
    }

    public async Task<Loan?> GetById(int id) {
        var loan = await _context.Loans
            .Include(l => l.User)
            .Include(l => l.Book)
            .SingleOrDefaultAsync(l => l.Id == id);
        return loan;
    }
}
