using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(book => book.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(book => book.ISBN)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(book => book.ISBN)
            .IsUnique();

        builder.HasOne(book => book.Author)
            .WithMany(author => author.Books)
            .HasForeignKey(book => book.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(book => !book.IsDeleted);
    }
}
