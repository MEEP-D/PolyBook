
using System.ComponentModel.DataAnnotations;

namespace PolyBook.Models.DTOs
{
    public class GenreDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? GenreName { get; set; }

        public List<Book> Books { get; set; }
    }
}
