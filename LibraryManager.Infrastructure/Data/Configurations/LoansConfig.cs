using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Infrastructure.Data.Configurations; 
public class LoansConfig : IEntityTypeConfiguration<Loan> {
    public void Configure(EntityTypeBuilder<Loan> builder) {
        builder.HasKey(l => l.Id);
        builder.HasOne(l => l.User);
        builder.HasOne(l => l.Book);
    }
}
