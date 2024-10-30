using PolyBook.Data;
using PolyBook.Models;
using Microsoft.EntityFrameworkCore;
using PolyBook.Repositories;
namespace PolyBook.HomeReponsitory
{
    public class HomeReponsitory : IHomeRepository
    {
        private readonly ApplicationDbContext _dbContext;        
        public HomeReponsitory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Genre>> Genres()
        {
            return await _dbContext.Genres.ToListAsync();
        }
        public async Task<IEnumerable<Book>> LayThongTinSachTuDb(string keySearch = "", int theLooaiId = 0)
        {
            //chuyển từ dạng chuỗi sang chữ thường
            keySearch = keySearch.ToLower();

            IEnumerable<Book> books = await (from sach in _dbContext.Books
                                             join theLoai in _dbContext.Genres
                                             on sach.GenreId equals theLoai.Id
                                             where string.IsNullOrWhiteSpace(keySearch) ||
                                             (sach != null && sach.BookName != null) &&
                                             sach.BookName.ToLower().StartsWith(keySearch.ToLower())
                                             select new Book
                                             {
                                                 Id  = sach.Id,
                                                 BookName = sach.BookName,
                                                 Image = sach.Image,
                                                 AuthorName = sach.AuthorName,
                                                 Price = sach.Price,
                                                 GenreId = sach.GenreId,
                                                 GenreName = sach.GenreName,
                                                 Quantity = sach.Quantity,
                                             }
                                             ).ToListAsync();
            return books;
         }
    }
}
