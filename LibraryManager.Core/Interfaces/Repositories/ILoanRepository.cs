using LibraryManager.Core.Entities;
using LibraryManager.Core.Models;

namespace LibraryManager.Core.Interfaces.Repositories; 
public interface ILoanRepository {
    Task<bool> CheckOut(CreateLoanInputModel loan);
    Task<bool> CheckIn(int id);
    Task<IEnumerable<Loan>> GetAll();
    Task<Loan> GetById(int id);
}
