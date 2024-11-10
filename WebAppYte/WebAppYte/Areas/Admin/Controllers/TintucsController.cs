using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAppYte.Models;

namespace WebAppYte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TintucsController : Controller
    {
        // GET: Admin/Tintucs
        private readonly WebDatLichKhamContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TintucsController(WebDatLichKhamContext context, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Admin/Tintucs
        public ActionResult Index()
        {
            using(var context = new WebDatLichKhamContext())
            {
                List<BaiViet> list = context.BaiViets.Include(x=> x.MaloaiNavigation).ToList();
                return View(list);
            }
        }

        // GET: Admin/Tintucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            BaiViet tintuc = db.BaiViets.Include(x=> x.MaloaiNavigation).FirstOrDefault(x=> x.Mabv == id);
            if (tintuc == null)
            {
                return NotFound();
            }
            return View(tintuc);
        }

        // GET: Admin/Tintucs/Create
        public ActionResult Create(int? id)
        {
            ViewBag.mabn = new SelectList(db.NguoiDungs.Where(h => h.Mand == id), "Mand", "Hoten");
            ViewBag.maloai = new SelectList(db.Loais, "Maloai", "Tenloai");
            return View();
        }

        // POST: Admin/Tintucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [System.Web.Mvc.ValidateInput(false)]
        public ActionResult Create([Bind("Mabv, Tieude, Noidung, Hinhanh, Mota, Ngaydang, Maloai, Mand")] BaiViet tintuc ,string anh)
        {
                tintuc.Hinhanh = anh;
            if (ModelState.IsValid)
            {
                var d = DateTime.Now;
                tintuc.Ngaydang = d;
                db.BaiViets.Add(tintuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maloai = new SelectList(db.Loais, "Maloai", "Tenloai", tintuc.Maloai);


            return View(tintuc);
        }

        // GET: Admin/Tintucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BaiViet tintuc = db.BaiViets.Find(id);
            if (tintuc == null)
            {
                return NotFound();
            }
            ViewBag.ngay = (tintuc.Ngaydang).Value.ToString("yyyy-MM-dd");
            ViewBag.maloai = new SelectList(db.Loais, "Maloai", "Tenloai", tintuc.Maloai);
            return View(tintuc);
        }

        // POST: Admin/Tintucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [System.Web.Mvc.ValidateInput(false)]
        public ActionResult Edit([Bind("Mabv, Tieude, Noidung, Hinhanh, Mota, Ngaydang, Maloai, Mand")] BaiViet tintuc, string anh)
        {
            tintuc.Hinhanh = anh;

            if (ModelState.IsValid)
            {
                db.Entry(tintuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maloai = new SelectList(db.Loais, "Maloai", "Tenloai", tintuc.Maloai);
            return View(tintuc);
        }

        // GET: Admin/Tintucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BaiViet tintuc = db.BaiViets.Find(id);
            if (tintuc == null)
            {
                return NotFound();
            }
            return View(tintuc);
        }

        // POST: Admin/Tintucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiViet tintuc = db.BaiViets.Find(id);
            db.BaiViets.Remove(tintuc);
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