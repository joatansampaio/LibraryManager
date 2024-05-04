namespace LibraryManager.Core.Models;
public class UpdateLoanInputModel {
    public DateTime BorrowedAt { get; set; }
    public DateTime? ReturnedAt { get; set; }
}
