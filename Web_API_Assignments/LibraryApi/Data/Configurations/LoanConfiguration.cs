using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Data.Configurations;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.HasKey(loan => new { loan.BookId, loan.BorrowerId });

        builder.HasOne(loan => loan.Book)
            .WithMany(book => book.Loans)
            .HasForeignKey(loan => loan.BookId);

        builder.HasOne(loan => loan.Borrower)
            .WithMany(borrower => borrower.Loans)
            .HasForeignKey(loan => loan.BorrowerId);

        builder.HasQueryFilter(loan => !loan.IsDeleted);
    }
}
