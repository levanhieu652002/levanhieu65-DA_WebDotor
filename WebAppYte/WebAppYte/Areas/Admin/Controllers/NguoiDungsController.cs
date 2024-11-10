using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebAppYte.Models;

namespace WebAppYte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NguoiDungsController : Controller
    {
        // GET: Admin/NguoiDungs
        private readonly WebDatLichKhamContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NguoiDungsController(WebDatLichKhamContext context, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Admin/NguoiDungs
        public ActionResult Index()
        {
            var nguoiDungs = db.BenhNhans.Where(x => x.Trangthai == 1) ;
            return View(nguoiDungs.ToList());
        }

        // GET: Admin/NguoiDungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BenhNhan nguoiDung = db.BenhNhans.Find(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }
            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungs/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Admin/NguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Mabn,Tenbn, Sdt,Email, Diachi, Ngaysinh, Gioitinh,Tendn, Mk")] BenhNhan nguoiDung)
        {
            if (ModelState.IsValid)
            {
                nguoiDung.Trangthai = 1;
                db.BenhNhans.Add(nguoiDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

          
            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BenhNhan nguoiDung = db.BenhNhans.Find(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }
            @ViewBag.ngay = (nguoiDung.Ngaysinh).Value.ToString("yyyy-MM-dd");
            return View(nguoiDung);
        }

        // POST: Admin/NguoiDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Mabn,Tenbn, Sdt,Email, Diachi, Ngaysinh, Gioitinh,Tendn, Mk")] BenhNhan nguoiDung)
        {
            if (ModelState.IsValid)
            {
                nguoiDung.Trangthai = 1;
                db.Entry(nguoiDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
         
            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            BenhNhan nguoiDung = db.BenhNhans.Find(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }
            @ViewBag.ngay = (nguoiDung.Ngaysinh).Value.ToString("yyyy-MM-dd");
            return View(nguoiDung);
        }

        // POST: Admin/NguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int mabn, string tenbn,string sdt,string email, string diachi, DateTime ngaysinh, string gioitinh, string tendn, string mk)
        {
            BenhNhan nguoiDung = db.BenhNhans.Find(mabn);
            nguoiDung.Mabn = mabn;
            nguoiDung.Tenbn = tenbn;
            nguoiDung.Sdt = sdt;
            nguoiDung.Email = email;
            nguoiDung.Diachi = diachi;
            nguoiDung.Ngaysinh = ngaysinh;
            nguoiDung.Gioitinh = gioitinh;
            nguoiDung.Tendn = tendn;
            nguoiDung.Mk = mk;
            nguoiDung.Trangthai = 0;
            db.Entry(nguoiDung).State = EntityState.Modified;
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