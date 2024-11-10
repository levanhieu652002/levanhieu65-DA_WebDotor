using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using WebAppYte.Models;
using X.PagedList;

namespace WebAppYte.Controllers
{
    public class CaKhamController : Controller
    {
        private readonly WebDatLichKhamContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CaKhamController(WebDatLichKhamContext context, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: CaKham

        public ActionResult Index(int id, int? page)
        {
           
            var lich =  db.CaKhams.Where(x => x.Mand == id&& x.Trangthai==1).OrderByDescending(x => x.Ngaykham).ThenBy(x => x.Maca).ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(lich.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Create(int? id)
        {
            ViewBag.mand = new SelectList(db.NguoiDungs.Where(h => h.Mand == id), "Mand", "Hoten");
            ViewBag.id = id;
            return View();
        }

        // POST: Admin/Tintucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[System.Web.Mvc.ValidateInput(false)]
        public ActionResult Create([Bind("Maca, Ngaykham,  Hinhthuc,Ca,  Mand")] CaKham cakham)
        {
            if (ModelState.IsValid)
            {
               
                db.CaKhams.Add(cakham);
                db.SaveChanges();
                return RedirectToAction("Index", "CaKham", new { id = cakham.Mand });
              
            }
            ViewBag.mand = new SelectList(db.NguoiDungs, "Mand", "Hoten",cakham.Mand);

            return View(cakham);
        }

        // GET: Admin/Tintucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            CaKham cakham = db.CaKhams.Find(id);
            if (cakham == null)
            {
                return NotFound();
            }
            @ViewBag.ngay = (cakham.Ngaykham).Value.ToString("yyyy-MM-dd");

            return View(cakham);
        }

        // POST: Admin/Tintucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [System.Web.Mvc.ValidateInput(false)]
        public ActionResult Edit(int maca, string hinhthuc, DateTime ngaykham, string ca)
        {
          

            if (ModelState.IsValid)
            {
                var httpContext = _httpContextAccessor.HttpContext;
                var userBSJson = httpContext.Session.GetString("userBS");
                var userBS = !string.IsNullOrEmpty(userBSJson) ? JsonSerializer.Deserialize<NguoiDung>(userBSJson) : null;
                CaKham cakham = db.CaKhams.Find(maca);
                cakham.Hinhthuc = hinhthuc;
                cakham.Ngaykham = ngaykham;
                cakham.Ca = ca;
                cakham.Trangthai = 1;
                cakham.Mand = userBS.Mand;
                db.Entry(cakham).State = EntityState.Modified;
                db.SaveChanges();
            
             
                return RedirectToAction("Index",  new { id = userBS.Mand });
            }

            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            CaKham cakham = db.CaKhams.Find(id);
            if (cakham == null)
            {
                return NotFound();
            }
            @ViewBag.ngay = (cakham.Ngaykham).Value.ToString("yyyy-MM-dd");

            return View(cakham);
        }

        // POST: Admin/Tintucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [System.Web.Mvc.ValidateInput(false)]
        public ActionResult Delete(int maca, string hinhthuc, DateTime ngaykham, string ca)
        {


            if (ModelState.IsValid)
            {
                var httpContext = _httpContextAccessor.HttpContext;
                var userBSJson = httpContext.Session.GetString("userBS");
                var userBS = !string.IsNullOrEmpty(userBSJson) ? JsonSerializer.Deserialize<NguoiDung>(userBSJson) : null;
                CaKham cakham = db.CaKhams.Find(maca);
                cakham.Hinhthuc = hinhthuc;
                cakham.Ngaykham = ngaykham;
                cakham.Ca = ca;
                cakham.Trangthai = 0;
                cakham.Mand = userBS.Mand;
                db.Entry(cakham).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Index", new { id = userBS.Mand });
            }

            return View();
        }
        // GET: Admin/Tintucs/Delete/5


        // POST: Admin/Tintucs/Delete/5


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