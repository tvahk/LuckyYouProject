using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using DAL.Interfaces;
using DomainLogic;
using WebApiThrottle;
using WebService.Models;

namespace WebService.Controllers
{
    /// <summary>
    /// MVC Controller for web service admin page
    /// </summary>
    public class AdminController : Controller
    {

        private readonly ApplicationUserManager _userManager;
        private readonly IUOW _uow;

        public AdminController(ApplicationUserManager userManager, IUOW uow)
        {
            _uow = uow;
            _userManager = userManager;
        }

    
        public ActionResult Index()
        {
            return View("Index", new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel loginModel)
        {
            if (loginModel.Username == Config.AdminUsername && loginModel.Password == Config.AdminPassword)
            {
                Session["LoggedIn"] = true;
                return Manage();
            }
            return View("Index", new LoginModel());
        }

        public ActionResult Manage()
        {
            if (Session["LoggedIn"] == null || !(bool) Session["LoggedIn"])
                return Index();
            
            var model = new ManageModel
            {
                Users = _uow.Users.All,
            };
            return View("Manage", model);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (Session["LoggedIn"] == null || !(bool)Session["LoggedIn"])
                return Index();
            var user = _uow.Users.GetById(id);
            var roles = await _userManager.GetRolesAsync(id);
            var isAdmin = roles.Any(role => role == "Admin");
            var model = new EditModel
            {
                User = user,
                IsAdmin = isAdmin
            };
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditModel model)
        {
            
            if (!(bool)Session["LoggedIn"])
                return Index();
            var modifiedUser = _uow.Users.GetById(model.User.Id);
            if (modifiedUser != null)
            {
                modifiedUser.ConnectionsMinuteRate = model.User.ConnectionsMinuteRate;
                modifiedUser.ConnectionsWeekRate = model.User.ConnectionsWeekRate;
                _uow.Users.Update(modifiedUser);
                var roles = await _userManager.GetRolesAsync(model.User.Id);
                var isAdmin = roles.Any(role => role == "Admin");

                if (isAdmin != model.IsAdmin)
                {
                    if (model.IsAdmin)
                        await _userManager.AddToRoleAsync(model.User.Id, "Admin");
                    else
                        await _userManager.RemoveFromRoleAsync(model.User.Id, "Admin");
                }
                var policyRepository = new PolicyCacheRepository();
                var policy = policyRepository.FirstOrDefault(ThrottleManager.GetPolicyKey());
                policy.ClientRules[modifiedUser.UserName] =
                    new RateLimits { PerMinute = model.User.ConnectionsMinuteRate, PerWeek = model.User.ConnectionsWeekRate };
            }
            return await Edit(model.User.Id);
        }
    }
}
