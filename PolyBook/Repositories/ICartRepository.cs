using PolyBook.Models;

namespace PolyBook.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int bookId);
/*        Task DeleteBook(Book book);
*/        Task<int> RemoveItem(int bookId);
        Task<ShoppingCart> GetUserCart(int id);
        Task<IEnumerable<Book>> GetBooks();
        Task UpdateBook(Book book);
    }
}
