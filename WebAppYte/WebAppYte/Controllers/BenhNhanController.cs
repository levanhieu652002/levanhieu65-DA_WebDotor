

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAppYte.DAO;
using WebAppYte.Models;
using X.PagedList;

namespace WebAppYte.Controllers
{
    public class BenhNhanController : Controller
    {
        // GET: BenhNhan
        private readonly WebDatLichKhamContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BenhNhanController(WebDatLichKhamContext context, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public ActionResult Index()
        {
            var benhnhan= db.BenhNhans.ToList();

            return View(benhnhan);

        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BenhNhan benhnhan = db.BenhNhans.Find(id);
            @ViewBag.ngay = (benhnhan.Ngaysinh).Value.ToString("yyyy-MM-dd");
            if (benhnhan == null)
            {
                return NotFound();
            }
            return View(benhnhan);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BenhNhan benhnhan = db.BenhNhans.Find(id);
            if (benhnhan == null)
            {
                return NotFound();
            }
            @ViewBag.ngay = (benhnhan.Ngaysinh).Value.ToString("yyyy-MM-dd");
            return View(benhnhan);
        }

        // POST: Nguoidung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Mabn,Tenbn,Sdt,Email,Diachi,Ngaysinh, Gioitinh, Tendn,Mk")] BenhNhan benhnhan)
        {
            if (ModelState.IsValid)
            {
                benhnhan.Trangthai = 1;
                db.Entry(benhnhan).State = EntityState.Modified;
                db.SaveChanges();
  
                return RedirectToAction("Details", "BenhNhan", new { id = benhnhan.Mabn });
            } 
     
            return View(benhnhan);
        }

        public ActionResult Histories(int id, int? page)
        {
            LichKham ls = new LichKham();
            var lichKhams = ls.DSLichKham().Where(h => h.mabn == id).OrderByDescending(x => x.ngaydat).ThenBy(x => x.madat);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(lichKhams.ToPagedList(pageNumber, pageSize));
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