using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
namespace LibrarySystem.Data;
public class AppDbContext : DbContext {
 public DbSet<Book> Books => Set<Book>(); public DbSet<Author> Authors => Set<Author>(); public DbSet<Borrower> Borrowers => Set<Borrower>(); public DbSet<Loan> Loans => Set<Loan>();
 protected override void OnConfiguring(DbContextOptionsBuilder o) => o.UseSqlite("Data Source=library.db");
 protected override void OnModelCreating(ModelBuilder m) {
  m.Entity<Book>().HasOne(b=>b.Author).WithMany(a=>a.Books).HasForeignKey(b=>b.AuthorId);
  m.Entity<Loan>().HasKey(l=>new{l.BookId,l.BorrowerId,l.LoanDate});
  m.Entity<Loan>().HasOne(l=>l.Book).WithMany(b=>b.Loans).HasForeignKey(l=>l.BookId);
  m.Entity<Loan>().HasOne(l=>l.Borrower).WithMany(b=>b.Loans).HasForeignKey(l=>l.BorrowerId);
 }
}