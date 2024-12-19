using Microsoft.AspNetCore.Mvc.Rendering;

namespace PolyBook.Models.DTOs
{
    public class UpdateOrderStatusModel
    {
        public int OrderId { get; set; }
        public int OrdersStatus { get; set; }
        public IEnumerable<SelectListItem>? OrderStatusList;
    }
}
