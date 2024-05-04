using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Infrastructure.Data.Configurations; 
public class BooksConfig : IEntityTypeConfiguration<Book> {
    public void Configure(EntityTypeBuilder<Book> builder) {
        builder.HasKey(b => b.Id);
    }
}
