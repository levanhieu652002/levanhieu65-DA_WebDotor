

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAppYte.Models;

namespace WebAppYte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BenhAnsController : Controller
    {
        // GET: Admin/BenhAns
        private readonly WebDatLichKhamContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BenhAnsController(WebDatLichKhamContext context, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Admin/BenhAns
        public ActionResult Index()
        {
            var benhans = db.BenhAns.Include(x => x.MabnNavigation)
                .Include(x => x.MabsNavigation)
                .Where(x => x.Trangthai == 1);

            return View(benhans.ToList());
        }

        // GET: Admin/BenhAns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var benhnhans = db.BenhNhans.Where(x => x.Trangthai == 1);
            var bacsis = db.NguoiDungs.Where(x => x.Trangthai == 1);

            ViewData["benhnhans"] = benhnhans.ToList();
            ViewData["bacsis"] = bacsis.ToList();
            BenhAn benhan = db.BenhAns.Find(id);
            if (benhan == null)
            {
                return NotFound();
            }
            return View(benhan);
        }

        // GET: Admin/BenhAns/Create
        public ActionResult Create()
        {
            var benhnhans = db.BenhNhans.Where(x => x.Trangthai == 1);
            var bacsis = db.NguoiDungs.Where(x => x.Trangthai == 1);

            ViewData["benhnhans"] = benhnhans.ToList();
            ViewData["bacsis"] = bacsis.ToList();
            return View();
        }

        // POST: Admin/BenhAns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BenhAn benhan)
        {
            if (ModelState.IsValid)
            {
                benhan.Trangthai = 1;
                db.BenhAns.Add(benhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(benhan);
        }

        // GET: Admin/BenhAns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BenhAn benhan = db.BenhAns.Include(x => x.MabsNavigation).Include(x => x.MabnNavigation).Where(x => x.Maba == id).FirstOrDefault();

            var benhnhans = db.BenhNhans.Where(x => x.Trangthai == 1);
            var bacsis = db.NguoiDungs.Where(x => x.Trangthai == 1);

            ViewData["benhnhans"] = benhnhans.ToList();
            ViewData["bacsis"] = bacsis.ToList();
            if (benhan == null)
            {
                return NotFound();
            }
            return View(benhan);
        }

        // POST: Admin/BenhAns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BenhAn benhan)
        {
            if (ModelState.IsValid)
            {
                benhan.Trangthai = 1;
                db.Entry(benhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(benhan);
        }

        // GET: Admin/BenhAns/Delete/5
        public ActionResult Delete(int? id)
        {
            BenhAn benhan = db.BenhAns.Find(id);
            benhan.Trangthai = 0;
            db.Entry(benhan).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}