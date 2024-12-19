using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PolyBook.Data;
using PolyBook.Models;
using PolyBook.Models.DTOs;

namespace PolyBook.Repositories
{
    public interface IReportRepository
    {
     Task<IEnumerable<Book>> LayThongTinBanSanPhamTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc);
    }
    
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public ReportRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<IEnumerable<ResultBook>> LayThongTinBanSanPhamTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            //Khai báo các sqlparameter với giá trị của tham số phương thức  ( tham số hàm hay tham số truyền vào)
            var paramNgayBatDau = new SqlParameter("@ngayBatDau", ngayBatDau);
            var paramNgayKetThuc = new SqlParameter("@ngayKetThuc", ngayKetThuc);
            //var sachBanChay = await _dbcontext.Database.SqlQueryRaw<sachBanChay>("exec Usp")
            var result = await _dbcontext.Database.SqlQueryRaw<ResultBook>("exec Usp_GetResultBookByDate  @ngayBatDau, @ngayKetThuc", ngayBatDau, ngayKetThuc).ToListAsync();
            return result;
        }

        Task<IEnumerable<Book>> IReportRepository.LayThongTinBanSanPhamTheoNgay(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            throw new NotImplementedException();
        }
    }
}
