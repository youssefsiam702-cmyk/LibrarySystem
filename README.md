# LibrarySystem

## Open and run
1. Open `LibrarySystem.sln` in Visual Studio.
2. Allow NuGet restore to complete.
3. Press `Ctrl+F5`.

Requires the .NET 10 SDK and a Visual Studio version that supports .NET 10. The project uses SQLite and creates its local database automatically on first run.

## Relationships
Author → Books is one-to-many; Book ↔ Borrower is many-to-many through Loan. Loan uses (BookId, BorrowerId, LoanDate) as a composite key so the same book can be borrowed again later.

See `Database-Diagram.png` for the relationship diagram.
