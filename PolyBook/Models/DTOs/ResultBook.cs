namespace PolyBook.Models.DTOs;

    public record ResultBook(string BookName,string AuthorName, int TongSoSach);
    public record ResultBookViewModel(DateTime StartDate,DateTime EnDate,IEnumerable<ResultBook>ResultBookModels);


