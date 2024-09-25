using Microsoft.AspNetCore.Identity;
using PolyBook.Const;
using static System.Net.Mime.MediaTypeNames;

namespace PolyBook.Data
{
    public class DataSeed
    {
        public static async Task InitializeDefaultData(IServiceProvider serVice)
        {
            var manageUser = serVice.GetService<UserManager<IdentityUser>>();
            var manageRole = serVice.GetService <RoleManager<IdentityRole>>();
            //Thêm vai trò thêm 1 role vào database

            await manageRole.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await manageRole.CreateAsync(new IdentityRole(Roles.User.ToString()));
            ///Tạo thông tin mặc định cho tài khoản Admin :UserName,Email,xác thực Email

            var adminstration = new IdentityUser
            {
                UserName = "admin@test.com",
                Email = "admin@test.com",
                EmailConfirmed = true
            };
            var dbusers = await manageUser.FindByEmailAsync(adminstration.Email);

            //nếu tài khoản admin không tồn tại trong db hoặc chưa lưu tk admin

            if (dbusers is null) {
                //tạo tài khoản admin với pass Admin12345!@#$%
                var result = await manageUser.CreateAsync(adminstration, "Admin12345!@#$%");
                //Nếu tạo thành công thì thêm role cho tài khoản là admin
                if (result.Succeeded)
                {
                    await manageUser.AddToRoleAsync(adminstration, Roles.Admin.ToString());
                }
                else
                {
                    //in ra lỗi 
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }
         }
    }
}
