namespace Warehouse.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using Warehouse.Data;
    using Warehouse.Data.Models;
    using Warehouse.Models.Users;

    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly WarehouseDbContext context;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager, WarehouseDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        [Authorize]
        public IActionResult ChangePassword()
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = context.Users.FirstOrDefault(x => x.Id == userId);

            if (user.Password != model.CurrentPassword)
            {
                return this.View(model);
            }

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = await userManager.ChangePasswordAsync(user, user.Password, model.NewPassword);

            if (!result.Succeeded)
            {
                return this.View();
            }

            await signInManager.RefreshSignInAsync(user);

            user.Password = model.NewPassword;

            context.SaveChanges();
            return this.RedirectToAction("All", "Products");
        }
    }
}
