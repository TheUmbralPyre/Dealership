using Dealership.Data.DataModels.IdentityModels;
using Dealership.Entities.ViewModels.UserRoles;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dealership.Web.Areas.UserRoles.Controllers
{
    [Area("UserRoles")]
    public class UserRolesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper = null;

        public UserRolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var model = new List<UserRolesViewModel>();

            foreach (var user in users)
            {
                var userRolesViewModel = mapper.Map<UserRolesViewModel>(user);

                userRolesViewModel.Roles = await GetUserRoles(user);

                model.Add(userRolesViewModel);
            }

            return View(model);
        }

        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await userManager.GetRolesAsync(user));
        }
    }
}
