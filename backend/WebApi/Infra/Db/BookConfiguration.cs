using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain;

namespace WebApi.Infra.Db;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.BookId);

        builder.Property(b => b.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(b => b.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(b => b.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(b => b.TotalCopies)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(b => b.CopiesInUse)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(b => b.Type)
            .HasMaxLength(50);

        builder.Property(b => b.ISBN)
            .HasMaxLength(80);

        builder.Property(b => b.Category)
            .HasMaxLength(50);
    }
}
