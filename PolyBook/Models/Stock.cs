using System.ComponentModel.DataAnnotations.Schema;

namespace PolyBook.Models
{
    [Table("Stock")]
    public class Stock
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quyantity { get; set; }

        public Book? Book { get; set; }
    }
}
