using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces.Repositories;
using LibraryManager.Core.Interfaces.Services;
using LibraryManager.Core.Models;

namespace LibraryManager.Application.Services;
public class LoanService(ILoanRepository repository) : ILoanService {
    private readonly ILoanRepository _repository = repository;
    public async Task<bool> CheckIn(int id) {
        return await _repository.CheckIn(id);
    }

    public async Task<bool> CheckOut(CreateLoanInputModel loan) {
        return await _repository.CheckOut(loan);
    }

    public async Task<IEnumerable<Loan>> GetAll() {
        return await _repository.GetAll();
    }

    public async Task<Loan> GetById(int id) {
        return await _repository.GetById(id);
    }
}
