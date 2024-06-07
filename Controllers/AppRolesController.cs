using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace HouseBuying.Controllers
{
    public class AppRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AppRolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        
        }
        [HttpGet]
        public IActionResult Creat()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Creat(IdentityRole model)
        {
            //avoid duplicate role
            if(!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();    
            }
            return RedirectToAction("Index");
        }
    }
}
