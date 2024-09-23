using System.ComponentModel.DataAnnotations;//Required
using System.ComponentModel.DataAnnotations.Schema;
namespace PolyBook.Models
{
    [Table("Book")]
    public class Book
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
        public string? Image {  get; set; }

        [Required]
        public int GenreId { get; set; }
       
        public Genre Genre { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }

        public Stock Stock { get; set; }


        [NotMapped] //không ánh xạ dữ liệu GenreName trong bảng Genre
         public string GenreName { get; set; }

        [NotMapped]//không ánh xạ dữ liệu Quantity trong bảng Stock
        public int Quantity { get; set; }

    }
}
