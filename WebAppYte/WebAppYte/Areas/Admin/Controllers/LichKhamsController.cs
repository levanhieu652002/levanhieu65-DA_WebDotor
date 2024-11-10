using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebAppYte.DAO;
using WebAppYte.Models;

namespace WebAppYte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LichKhamsController : Controller
    {
        // GET: Admin/LichKhams
        private readonly WebDatLichKhamContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LichKhamsController(WebDatLichKhamContext context, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
            _httpContextAccessor = httpContextAccessor;
        }
        LichKham ls = new LichKham();
        

        // GET: Admin/LichKhams
        public ActionResult Index()
        {
            
            var lichKhams = ls.DSLichKham().OrderByDescending(x=>x.maca);
            return View(lichKhams.ToList());
        }


 

        // GET: Admin/LichKhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            using (var context = new WebDatLichKhamContext())
            {
                DatLich datlich = context.DatLiches.FirstOrDefault(x => x.Madat == id);
                context.DatLiches.Remove(datlich);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // POST: Admin/LichKhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatLich lichKham = db.DatLiches.Find(id);
            db.DatLiches.Remove(lichKham);
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