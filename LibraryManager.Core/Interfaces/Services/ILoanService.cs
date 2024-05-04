using LibraryManager.Core.Entities;
using LibraryManager.Core.Models;

namespace LibraryManager.Core.Interfaces.Services; 
public interface ILoanService {
    Task<bool> CheckOut(CreateLoanInputModel loan);
    Task<bool> CheckIn(int id);
    Task<IEnumerable<Loan>> GetAll();
    Task<Loan> GetById(int id);
}
