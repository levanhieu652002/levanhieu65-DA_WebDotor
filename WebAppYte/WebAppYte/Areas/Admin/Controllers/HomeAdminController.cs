using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppYte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeAdminController( IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangXuatAd()
        {
            // Đặt giá trị cho Session
            _httpContextAccessor.HttpContext.Session.SetString("userAdmin", string.Empty);
            return RedirectToAction("Index", "HomeAdmin");
        }
    }
}