using Microsoft.AspNetCore.Identity;
using PolyBook.Models;

namespace PolyBook.Repositories
{
    public interface IUserManager
    {
        string UserName { get; }
    }
    public class UserManager : IUserManager
    {
        public string UserName => throw new NotImplementedException();
    }
}