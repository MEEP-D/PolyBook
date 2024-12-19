using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PolyBook.Models.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        [Required]//trường dữ liệu không thể trống trên giao diện
        [MaxLength(100)]
        public string? BookName { get; set; }//? cho phép giá trị là null nếu k có giá trị nào được gán,có thể là null trên database

        [Required]
        [MaxLength(100)]
        public string? AuthorName { get; set; }

        [Required]
        public double Price { get; set; }

        //nvarchar(max)
        public string? Image { get; set; }

        [Required]
        public int GenreId { get; set; }

        //ImageFile tương đương với một ảnh được tải lên qua
        //1 form trong trang web
        //IFormFile gửi 1 yêu cầu 
            //Khi người dùng tải lên 1 hình ảnh (ImageFile) lưu vào máy chủ

        public IFormFile? ImageFile { get; set; }
        public IEnumerable<SelectListItem>? GenreList { get; set; }
    }
}
