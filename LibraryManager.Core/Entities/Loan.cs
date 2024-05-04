namespace LibraryManager.Core.Entities; 
public class Loan: BaseEntity {
    public int BookId { get; set; }
    public int UserId { get; set; }
    public Book Book { get; set; }
    public User User { get; set; }
    public DateTime BorrowedAt { get; private set; }
    public DateTime? ReturnedAt { get; private set; }

    public void CheckOut() {
        if (ReturnedAt != null) {
            throw new InvalidOperationException("Cannot check out a book that has already been returned.");
        }
        if (BorrowedAt != default) {
            throw new InvalidOperationException("Cannot check out a book that has already been checked out.");
        }
        BorrowedAt = DateTime.Now;
    }

    public void CheckIn() {
        if (ReturnedAt != null) {
            throw new InvalidOperationException("Cannot check in a book that has already been returned.");
        }
        if (BorrowedAt == default) {
            throw new InvalidOperationException("Cannot check in a book that has not been checked out.");
        }
        ReturnedAt = DateTime.Now;
    }
}

