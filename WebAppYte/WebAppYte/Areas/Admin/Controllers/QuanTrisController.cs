using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebAppYte.Models;

namespace WebAppYte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuanTrisController : Controller
    {
        // GET: Admin/QuanTris
        private readonly WebDatLichKhamContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public QuanTrisController(WebDatLichKhamContext context, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Admin/QuanTris
        public ActionResult Index()
        {
            var quanTris = db.NguoiDungs.Include(q => q.MakhoaNavigation).Include(q => q.MachinhanhNavigation).Where(x => x.Trangthai == 1);
            var model = quanTris.ToList();
            return View(model);
        }

        // GET: Admin/QuanTris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            NguoiDung quanTri = db.NguoiDungs.Find(id);
            if (quanTri == null)
            {
                return NotFound();
            }
            return View(quanTri);
        }

        // GET: Admin/QuanTris/Create
        public ActionResult Create()
        {
            ViewBag.makhoa = new SelectList(db.Khoas, "Makhoa", "Tenkhoa");
            ViewBag.machinhanh = new SelectList(db.ChiNhanhs, "Machinhanh", "Diachi");
            return View();
        }

        // POST: Admin/QuanTris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Mand,Hoten,Diachi,Ngaysinh,Gioitinh,Sdt,Email,Chucvu,Hocham,Hocvi,Gioithieu,Makhoa,Machinhanh,Tendn, Mk,Quyen,Anh")] NguoiDung quanTri, string anh)
        {
            quanTri.Anh = anh;
            if (ModelState.IsValid)
            {
                quanTri.Trangthai = 1;
                db.NguoiDungs.Add(quanTri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.makhoa = new SelectList(db.Khoas, "Makhoa", "Tenkhoa", quanTri.Makhoa);
            ViewBag.machinhanh = new SelectList(db.ChiNhanhs, "Machinhanh", "Diachi", quanTri.Machinhanh);
            return View(quanTri);
        }

        // GET: Admin/QuanTris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            NguoiDung quanTri = db.NguoiDungs.Find(id);
            if (quanTri == null)
            {
                return NotFound();
            }
            ViewBag.makhoa = new SelectList(db.Khoas, "Makhoa", "Tenkhoa", quanTri.Makhoa);
            ViewBag.machinhanh = new SelectList(db.ChiNhanhs, "Machinhanh", "Diachi", quanTri.Machinhanh);
            ViewBag.ngay = (quanTri.Ngaysinh).Value.ToString("yyyy-MM-dd");
            ViewBag.gioithieu = quanTri.Gioithieu;
            ViewBag.quyen = quanTri.Quyen;
            return View(quanTri);
        }

        // POST: Admin/QuanTris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Mand,Hoten,Diachi,Ngaysinh,Gioitinh,Sdt,Email,Chucvu,Hocham,Hocvi,Gioithieu,Makhoa,Machinhanh,Tendn, Mk,Quyen,Anh")] NguoiDung quanTri, string anh)
        {

            quanTri.Anh = anh;

            if (ModelState.IsValid)
            {
                quanTri.Trangthai = 1;
                db.Entry(quanTri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.makhoa = new SelectList(db.Khoas, "Makhoa", "Tenkhoa", quanTri.Makhoa);
            ViewBag.machinhanh = new SelectList(db.ChiNhanhs, "Machinhanh", "Diachi", quanTri.Machinhanh);
            return View(quanTri);
        }

        // GET: Admin/QuanTris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            NguoiDung quanTri = db.NguoiDungs.Find(id);
            if (quanTri == null)
            {
                return NotFound();
            }
            ViewBag.makhoa = new SelectList(db.Khoas, "Makhoa", "Tenkhoa", quanTri.Makhoa);
            ViewBag.machinhanh = new SelectList(db.ChiNhanhs, "Machinhanh", "Diachi", quanTri.Machinhanh);
            ViewBag.ngay = (quanTri.Ngaysinh).Value.ToString("yyyy-MM-dd");
            return View(quanTri);
        }

        // POST: Admin/QuanTris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int mand, string hoten, string diachi, DateTime ngaysinh, string gioitinh, string sdt, string email, string hocham, string hocvi, int makhoa, int machinhanh, string tendn, string mk, int quyen, string anh)
        {
            NguoiDung quanTri = db.NguoiDungs.Find(mand);
            quanTri.Hoten = hoten;
            quanTri.Diachi = diachi;
            quanTri.Ngaysinh = ngaysinh;
            quanTri.Gioitinh = gioitinh;
            quanTri.Sdt = sdt;
            quanTri.Email = email;

            quanTri.Hocham = hocham;
            quanTri.Hocvi = hocvi;

            quanTri.Makhoa = makhoa;
            quanTri.Machinhanh = machinhanh;
            quanTri.Tendn = tendn;
            quanTri.Mk = mk;
            quanTri.Quyen = quyen;
            quanTri.Anh = anh;
            quanTri.Trangthai = 0;
            db.Entry(quanTri).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.makhoa = new SelectList(db.Khoas, "Makhoa", "Tenkhoa", quanTri.Makhoa);
            ViewBag.machinhanh = new SelectList(db.ChiNhanhs, "Machinhanh", "Diachi", quanTri.Machinhanh);
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