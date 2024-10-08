using PolyBook.Models;

namespace PolyBook.Repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Book>> LayThongTinSachTuDb(string keySearch = "", int theLooaiId = 0);
        Task<IEnumerable<Genre>> Genres();
    }
}
