using PolyBook.Models;
using PolyBook.Data;
using Microsoft.EntityFrameworkCore;
using PolyBook.Models.DTOs;
using Microsoft.AspNetCore.Identity;
namespace PolyBook.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly UserManager<IdentityUser> _userManagers;

        private readonly IHttpContextAccessor _contextAccessor;

        public CartRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddItem(int bookId,int soluong)
        {
            throw new UnauthorizedAccessException("Hãy đăng nhập tài khoản");
        }

        public async Task<bool> DoCheckout(CheckoutModel model)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    throw new UnauthorizedAccessException("Hãy đăng nhập tài khoản");
                }

                var cart = await GetCart(userId);
                if (cart is null)
                {
                    throw new InvalidOperationException("Lỗi, giỏ hàng trống");
                }

                var chitietgiohang = _dbContext.CartDetails
                    .Where(i => i.ShoppingCartId == cart.Id).ToList();
                if (chitietgiohang.Count == 0)
                {
                    throw new InvalidOperationException("Giỏ hàng trống");
                }

                var trangthaidonhang = _dbContext.OrderStatuses
                    .FirstOrDefault(s => s.StatusName == "Pending");
                if (trangthaidonhang is null)
                {
                    throw new InvalidOperationException("Đơn hàng đang chờ xử lý");
                }

                var order = new Order
                {
                    UserId = userId,
                    CreatedDate = DateTime.UtcNow,
                    Name = model.Name,
                    Email = model.Email,
                    MobileNumber = model.MobileNumber,
                    PaymentMethod = model.PaymentMethod,
                    Address = model.Address,
                    IsPaid = false,
                    //OrderStatus = trangthaidonhang.Id,
                };

                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();

                foreach(var item in chitietgiohang)
                {
                    var chitietdonhang = new OrderDetail
                    {
                        BookId = item.BookId,
                        OrderId = item.Id,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                    };
                    //_dbContext.OrderDetails.Add();
                }

            }
            catch
            {
            }

            throw new NotImplementedException();
        }
        /*public async Task<int> AddItem(int bookId,int soluong) 
        {
            await _dbContext.SaveChangesAsync();
        }*/

        public async Task<ShoppingCart> GetCart(string userId)
        {
            var cart = await _dbContext.ShoppingCarts.FirstOrDefaultAsync(u => u.UserId == userId);

            return cart;
        }

        public async Task<int> GetCartItemCount(string userId)
        {
            throw new NotSupportedException();
        }

        public async Task<ShoppingCart> GetUserCart(int id)
        {
            throw new NotSupportedException();
        }

        public async Task<int> RemoveItem(int bookId)
        {
            throw new NotSupportedException();
        }

        private string GetUserId()
        {
            //nhận diện người dùng
            /*var nhandiennguoidung = _contextAccessor.HttpContext.User;
            string userId = _userManagers.GetUserId(nhandiennguoidung);
            return userId;*/

            //nhận diện người đùng
            var httpContext = _contextAccessor.HttpContext;

            //kiểm tra 
            if(httpContext?.User != null)
            {
               return _userManagers.GetUserId(httpContext.User);             
            }
            return null;

        }
    }
}
