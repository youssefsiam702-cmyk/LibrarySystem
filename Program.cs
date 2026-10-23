using LibrarySystem.Models;
using LibrarySystem.Data;
using Microsoft.EntityFrameworkCore;
using var db=new AppDbContext(); db.Database.EnsureCreated();
if(!db.Authors.Any()) { var a=new Author{Name="Naguib Mahfouz",BirthDate=new DateTime(1911,12,11)}; var b=new Book{Title="Palace Walk",ISBN="9789774163579",Author=a}; var borrower=new Borrower{Name="Omar Hassan",MembershipDate=DateTime.Today.AddMonths(-2)}; db.Loans.Add(new Loan{Book=b,Borrower=borrower,LoanDate=DateTime.Today}); db.SaveChanges(); }
Console.WriteLine("=== Library System ===");
foreach(var l in db.Loans.Include(x=>x.Book).ThenInclude(x=>x.Author).Include(x=>x.Borrower)) Console.WriteLine($"Book: {l.Book.Title} | Author: {l.Book.Author.Name} | Borrower: {l.Borrower.Name} | Loan: {l.LoanDate:d} | Return: {(l.ReturnDate.HasValue?l.ReturnDate.Value.ToString("d"):"Not yet returned")}");
Console.WriteLine("\nBooks by author:");
foreach(var a in db.Authors.Include(x=>x.Books)) Console.WriteLine($"{a.Name}: {string.Join(", ",a.Books.Select(b=>b.Title))}");
