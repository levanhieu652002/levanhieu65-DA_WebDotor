using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using WebAppYte.Models;

public class TinTucController : Controller
{
    private readonly WebDatLichKhamContext db;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private static int bacsiId = 0;
    public TinTucController(WebDatLichKhamContext context, IHttpContextAccessor httpContextAccessor)
    {
        db = context;
        _httpContextAccessor = httpContextAccessor;
    }
    // GET: TinTuc
    public ActionResult Index(int? page)
    {
        int pageNumber = (page ?? 1);
        int pageSize = 5;

        List<BaiViet> bai_viet = db.BaiViets.ToList();
        return View(bai_viet.ToPagedList(pageNumber, pageSize));

    }
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }
        BaiViet baiviet = db.BaiViets.Find(id);
        if (baiviet == null)
        {
            return NotFound();
        }
        return View(baiviet);
    }
    public ActionResult IndexBS(int id, int? page)
    {
        bacsiId = id;
        var hoiDaps = db.BaiViets.Include(x=> x.MaloaiNavigation).Where(h => h.Mand == id)
            .OrderByDescending(x => x.Ngaydang).ThenBy(x => x.Mabv).ToList();
        int pageSize = 5;
        int pageNumber = (page ?? 1);
        ViewBag.id = id;
        return View(hoiDaps.ToPagedList(pageNumber, pageSize));
    }
    public ActionResult Create(int? id)
    {
        ViewBag.mabn = new SelectList(db.NguoiDungs.Where(h => h.Mand == id), "Mand", "Hoten");
        ViewBag.maloai = new SelectList(db.Loais, "Maloai", "Tenloai");
        ViewBag.id = id;
        return View();
    }

    // POST: Admin/Tintucs/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [System.Web.Mvc.ValidateInput(false)]
    public ActionResult Create([Bind("Mabv, Tieude, Noidung, Hinhanh, Mota, Maloai, Mand")] BaiViet tintuc, string anh)
    {
            tintuc.Hinhanh = anh;
        if (ModelState.IsValid)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userBSJson = httpContext.Session.GetString("userBS");
            var userBS = !string.IsNullOrEmpty(userBSJson) ? JsonSerializer.Deserialize<NguoiDung>(userBSJson) : null;
            tintuc.Mand = userBS.Mand;
            var d = DateTime.Now;
            tintuc.Ngaydang = d;
            db.BaiViets.Add(tintuc);
            db.SaveChanges();
            return RedirectToAction("IndexBS", "TinTuc", new { id = userBS.Mand });
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
        ViewBag.maloai = new SelectList(db.Loais, "Maloai", "Tenloai", tintuc.Maloai);
        @ViewBag.ngay = (tintuc.Ngaydang).Value.ToString("yyyy-MM-dd");
        ViewBag.id = bacsiId;
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
            var httpContext = _httpContextAccessor.HttpContext;
            var userBSJson = httpContext.Session.GetString("userBS");
            var userBS = !string.IsNullOrEmpty(userBSJson) ? JsonSerializer.Deserialize<NguoiDung>(userBSJson) : null;
            db.Entry(tintuc).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexBS", "TinTuc", new { id = userBS.Mand });

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
        var httpContext = _httpContextAccessor.HttpContext;
        var userBSJson = httpContext.Session.GetString("userBS");
        var userBS = !string.IsNullOrEmpty(userBSJson) ? JsonSerializer.Deserialize<NguoiDung>(userBSJson) : null;
        BaiViet tintuc = db.BaiViets.Find(id);
        db.BaiViets.Remove(tintuc);
        db.SaveChanges();
        return RedirectToAction("IndexBS", "TinTuc", new { id = userBS.Mand });
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