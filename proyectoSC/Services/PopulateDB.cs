using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using proyectoSC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;
using static proyectoSC.ApiRoutes;

namespace proyectoSC.Services
{
    public class PopulateDB
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                DatabaseContext context= scope.ServiceProvider.GetService<DatabaseContext>();

                var user = new UserModel()
                {
                    UserName = "administrador",
                    NormalizedUserName = "ADMINISTRADOR",
                    SecurityStamp = Guid.NewGuid().ToString()
                };

               
                
                UserManager<UserModel> _userManager = scope.ServiceProvider.GetService<UserManager<UserModel>>();
                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<UserModel>();
                    var hashed = password.HashPassword(user, "P!1admin");
                    user.PasswordHash = hashed;
                    var userStore = new UserStore<UserModel>(context);
                    var result = await userStore.CreateAsync(user);
                }
                else
                {
                    var user1 = await context.Users.Where(u => u.UserName == user.UserName).FirstOrDefaultAsync();
                }   
            }
        }
    }
}
