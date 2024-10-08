using PolyBook.Data;
using PolyBook.Models;

namespace PolyBook.HomeReponsitory
{
    public class HomeReponsitory
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeReponsitory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /*public async Task<IEnumerable<Book>> LayThongTinSachTyDb(string keySearch="",int theLoaiId =0 )
        {
            //chuyển đổi chuỗi sang dạng chữ thường
            keySearch = keySearch.ToLower();
            IEnumerable<Book> books = await ().ToListAsync();
                        return books;
        }*/
    }
}
