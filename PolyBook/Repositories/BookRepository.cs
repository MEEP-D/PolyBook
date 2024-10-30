using PolyBook.Data;
using PolyBook.Models;

namespace PolyBook.Repositories
{
        public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteBook(Book book)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateBook(Book book)
        {
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Book?> GetBookById(int id) =>
        public async Task<IEnumerable<Book>> GetBooks() => await
        {
            //_dbContext.Books.Ge
        }
    }
}
