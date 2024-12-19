using Microsoft.AspNetCore.Mvc;
using PolyBook.Models;
using PolyBook.Models.DTOs;
using PolyBook.Repositories;
using System.Diagnostics;

namespace PolyBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;
        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }
        public async Task<IActionResult> Index(string keySearch="",int theLoaiId=0)
        {
            IEnumerable<Book> books = await _homeRepository.LayThongTinSachTuDb(keySearch, theLoaiId);
            IEnumerable<Genre> genges = await _homeRepository.Genres();
            BookDislayModel bookDislayModel = new BookDislayModel
            {
                Books = books,
                Genres = genges,
                keySearch = keySearch,
                theLoaiId = theLoaiId

            };
            return View();

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
