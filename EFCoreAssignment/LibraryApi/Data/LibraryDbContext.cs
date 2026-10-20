using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options)
    : DbContext(options)
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Borrower> Borrowers => Set<Borrower>();
    public DbSet<Loan> Loans => Set<Loan>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasIndex(book => book.ISBN)
            .IsUnique();

        modelBuilder.Entity<Book>()
            .Property(book => book.ISBN)
            .HasMaxLength(20)
            .IsRequired();

        modelBuilder.Entity<Book>()
            .HasOne(book => book.Author)
            .WithMany(author => author.Books)
            .HasForeignKey(book => book.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Loan>()
            .HasKey(loan => new { loan.BookId, loan.BorrowerId });

        modelBuilder.Entity<Loan>()
            .HasOne(loan => loan.Book)
            .WithMany(book => book.Loans)
            .HasForeignKey(loan => loan.BookId);

        modelBuilder.Entity<Loan>()
            .HasOne(loan => loan.Borrower)
            .WithMany(borrower => borrower.Loans)
            .HasForeignKey(loan => loan.BorrowerId);
    }
}
