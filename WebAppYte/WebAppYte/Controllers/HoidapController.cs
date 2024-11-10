using System.Linq;
using WebAppYte.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppYte.Controllers
{
    public class HoidapController : Controller
    {
        private readonly WebDatLichKhamContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HoidapController(WebDatLichKhamContext context, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Hoidap
        public ActionResult Index(int ? id, int? page)
        {
            var hoiDaps = db.HoiDaps.Include(h => h.MabnNavigation).Include(h => h.MandNavigation).Where(h => h.Mabn == id && h.Trangthai == 1)
                .OrderByDescending(x => x.Ngayhoi).ThenBy(x => x.Ma).ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.id = id;
            return View(hoiDaps.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ListAll(int? page)
        {
            if (page == null) page = 1;
        
            var model = db.HoiDaps.Include(h => h.MabnNavigation).Include(h => h.MandNavigation).Where(n => n.Trangthai == 1).OrderByDescending(x => x.Ngayhoi).ThenBy(x => x.Ma).ToList();
           
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Cauhoichoxuly(int? id, int? page)
        {
            var hoiDaps = db.HoiDaps.Include(h => h.MabnNavigation).Include(h => h.MandNavigation).Where(h => h.Mabn == id && h.Trangthai == 0)
                .OrderByDescending(x => x.Ngayhoi).ThenBy(x => x.Ma).ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.id = id;
            return View(hoiDaps.ToPagedList(pageNumber, pageSize));
        }


        // GET: Hoidap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            HoiDap hoiDap = db.HoiDaps.Find(id);
            if (hoiDap == null)
            {
                return NotFound();
            }
            return View(hoiDap);
        }

        // GET: Hoidap/Create
        public ActionResult Create(int? id)
        {
            ViewBag.mabn = new SelectList(db.BenhNhans.Where(h => h.Mabn == id), "Mabn", "Tenbn");
          

            return View();
        }

        // POST: Hoidap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Ma, Hoi, Ngayhoi, Ngaytl, Dap,  Mabn, Trangthai")] HoiDap hoiDap)
        {
            if (ModelState.IsValid)
            {
                var d = DateTime.Now;
                hoiDap.Ngayhoi = d;
                hoiDap.Trangthai = 0;
                db.HoiDaps.Add(hoiDap);
                db.SaveChanges();
                return RedirectToAction("Index","Hoidap" ,new { id = hoiDap.Mabn });
            }

            ViewBag.mabn = new SelectList(db.BenhNhans, "Mabn", "Tenbn", hoiDap.Mabn);

            return View(hoiDap);
        }

        // GET: Hoidap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            HoiDap hoiDap = db.HoiDaps.Find(id);
            if (hoiDap == null)
            {
                return NotFound();
            }
            ViewBag.mabn = new SelectList(db.BenhNhans.Where(x => x.Mabn == hoiDap.Mabn), "Mabn", "Tenbn", hoiDap.Mabn);
            ViewBag.mand = new SelectList(db.NguoiDungs.Where(x => x.Mand == hoiDap.Mand), "Mand", "Hoten", hoiDap.Mand);
            @ViewBag.ngay = (hoiDap.Ngayhoi).Value.ToString("yyyy-MM-dd");
            return View(hoiDap);
        }

        // POST: Hoidap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Ma, Hoi, Ngayhoi, Ngaytl, Dap, Mand, Mabn, Trangthai")] HoiDap hoiDap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoiDap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mabn = new SelectList(db.BenhNhans, "Mabn", "Tenbn", hoiDap.Mabn);
            ViewBag.mand = new SelectList(db.NguoiDungs, "Mand", "Hoten", hoiDap.Mand);
            return View(hoiDap);
        }

        // GET: Hoidap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            HoiDap hoiDap = db.HoiDaps.Find(id);
            if (hoiDap == null)
            {
                return NotFound();
            }
            return View(hoiDap);
        }

        // POST: Hoidap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoiDap hoiDap = db.HoiDaps.Find(id);
            db.HoiDaps.Remove(hoiDap);
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
