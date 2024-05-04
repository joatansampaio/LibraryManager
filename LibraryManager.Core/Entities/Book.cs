namespace LibraryManager.Core.Entities; 
public class Book: BaseEntity {
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public DateOnly PublishDate { get; set; }
}
