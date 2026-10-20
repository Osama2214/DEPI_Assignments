using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApi.Data.Configurations;

public class BorrowerConfiguration : IEntityTypeConfiguration<Borrower>
{
    public void Configure(EntityTypeBuilder<Borrower> builder)
    {
        builder.Property(borrower => borrower.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasQueryFilter(borrower => !borrower.IsDeleted);
    }
}
