using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using WebAppYte.Models;

namespace WebAppYte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HoiDapsController : Controller
    {
        // GET: Admin/HoiDaps
        private readonly WebDatLichKhamContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HoiDapsController(WebDatLichKhamContext context, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Admin/HoiDaps
        public ActionResult Index()
        {
            var hoiDaps = db.HoiDaps.Include(h => h.MabnNavigation).Include(h => h.MandNavigation);
            return View(hoiDaps.ToList());
        }

        // GET: Admin/HoiDaps/Details/5
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
      

        // GET: Admin/HoiDaps/Edit/5
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

        // POST: Admin/HoiDaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ma,string hoi,string dap, int mabn,DateTime ngayhoi )
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userBSJson = httpContext.Session.GetString("userAdmin");
            var admin = !string.IsNullOrEmpty(userBSJson) ? JsonSerializer.Deserialize<NguoiDung>(userBSJson) : null;
            HoiDap hd = db.HoiDaps.Where(x => x.Ma == ma).FirstOrDefault();
            if (ModelState.IsValid)
            {
               

                if (hd.Trangthai == 0 && dap != null)
                {
                   
                    hd.Trangthai = 1;
                    hd.Mand = admin.Mand;
                    hd.Ngaytl = DateTime.Now;
                }
                hd.Hoi = hoi;
                hd.Dap = dap;
                hd.Mabn = mabn;
              
                hd.Ngayhoi = ngayhoi;
                db.Entry(hd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mabn = new SelectList(db.BenhNhans, "Mabn", "Tenbn", mabn);
            ViewBag.mand = new SelectList(db.NguoiDungs, "Mand", "Hoten", hd.Mand);
            return View();
        }

        // GET: Admin/HoiDaps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            HoiDap hoiDap = db.HoiDaps.Include(x=> x.MabnNavigation).Include(x=> x.MandNavigation).FirstOrDefault(x=> x.Ma == id); 
            if (hoiDap == null)
            {
                return NotFound();
            }
            return View(hoiDap);
        }

        // POST: Admin/HoiDaps/Delete/5
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