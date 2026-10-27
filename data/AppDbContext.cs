
\\
gpt used
using AssessmentA3.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentA3.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Member> Members => Set<Member>();
    public DbSet<Borrow> Borrows => Set<Borrow>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Only BookID and BorrowDate form the primary key.
        modelBuilder.Entity<Borrow>()
            .HasKey(b => new { b.BookID, b.BorrowDate });

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Borrow>()
            .HasOne(b => b.Book)
            .WithMany(book => book.Borrows)
            .HasForeignKey(b => b.BookID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Borrow>()
            .HasOne(b => b.Member)
            .WithMany(member => member.Borrows)
            .HasForeignKey(b => b.MemberID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}