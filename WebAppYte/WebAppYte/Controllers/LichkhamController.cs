using System;
using System.Collections.Generic;
using System.Linq;
using WebAppYte.DAO;
using WebAppYte.Models;
using X.PagedList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebAppYte.wwwroot.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace WebAppYte.Controllers
{
    public class LichkhamController : Controller
    {
        private readonly WebDatLichKhamContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LichkhamController(WebDatLichKhamContext context, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
            _httpContextAccessor = httpContextAccessor;
        }


        // GET: Lichkham
        public class listofSegments
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }
        public ActionResult Index(int? id, int? page)
        {
            LichKham ls = new LichKham();

            var lichKhams = ls.DSLichKham().Where(h => h.mabn == id).OrderByDescending(x => x.ngaydat).ThenBy(x => x.madat);
            foreach (var item in lichKhams)
            {
                DateTime ngayKham = DateTime.ParseExact(item.ngaykham.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ngayHienTai = DateTime.Today;
                if (ngayKham < ngayHienTai && @item.trangthai == 0)
                {
                    DatLich dl = db.DatLiches.Find(@item.madat);
                    dl.Trangthai = 3;
                    db.Entry(dl).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.id = id;
            return View(lichKhams.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Dangxuly(int? id, int? page)
        {

            LichKham ls = new LichKham();
            var lichKhams = ls.DSLichKham().Where(h => h.mabn == id && h.trangthai == 0).OrderByDescending(x => x.ngaydat).ThenBy(x => x.madat);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.id = id;
            return View(lichKhams.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Daxacnhan(int? id, int? page)
        {
            LichKham ls = new LichKham();
            var lichKhams = ls.DSLichKham().Where(h => h.mabn == id && h.trangthai == 1).OrderByDescending(x => x.ngaydat).ThenBy(x => x.madat);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.id = id;
            return View(lichKhams.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Datuvanxong(int? id, int? page)
        {
            LichKham ls = new LichKham();
            var lichKhams = ls.DSLichKham().Where(h => h.mabn == id && (h.trangthai == 2 || h.trangthai == 4)).OrderByDescending(x => x.ngaydat).ThenBy(x => x.madat);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.id = id;
            return View(lichKhams.ToPagedList(pageNumber, pageSize));
        }

        // GET: Lichkham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            LichKham ls = new LichKham();
            LichKham lichkham = ls.DSLichKham().Where(x => x.madat == id).FirstOrDefault();

            if (lichkham == null)
            {
                return NotFound();
            }
            return View(lichkham);
        }


        public ActionResult Create(string hinhthuc, string chinhanh, string khoa, string bacsi, string ngaykham, string cakham, string mota)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userBSJson = httpContext.Session.GetString("user");
            var u = !string.IsNullOrEmpty(userBSJson) ? JsonSerializer.Deserialize<BenhNhan>(userBSJson) : null;

            hinhthuc = LKSave.hinhthuc;
            chinhanh = LKSave.chinhanh;
            khoa = LKSave.khoa;
            bacsi = LKSave.bacsi;
            ngaykham = LKSave.ngaykham;
            cakham = LKSave.cakham;
            var segmentList = new List<listofSegments>();
            listofSegments segmentItem;
            var strArr = new string[] { "Ca sáng", "Ca chiều, tối", "Khám online" };
            for (int index = 0; index < strArr.Length; index++)
            {
                segmentItem = new listofSegments();
                segmentItem.Text = strArr[index];
                segmentItem.Value = strArr[index];
                segmentList.Add(segmentItem);
            }

            ViewBag.hinhthuc = segmentList;
            ViewBag.ht = hinhthuc;

            List<string> dd = (from p in db.ChiNhanhs select p.Diachi).ToList();
            ViewBag.chinhanh = dd;
            ViewBag.cn = chinhanh;


            List<string> tenkhoa = (from p in db.Khoas select p.Tenkhoa).ToList();
            ViewBag.khoa = tenkhoa;
            ViewBag.k = khoa;


            TTNguoiDung ls = new TTNguoiDung();
            var bss = ls.ListNguoiDung().ToList();
            if (chinhanh != null && khoa != null)
            {

                bss = ls.ListNguoiDung().Where(x => x.tenchinhanh == chinhanh && x.tenkhoa == khoa).ToList();

            }
            var bs1 = (from p in bss select p.hoten).ToList();
            ViewBag.bacsi = bs1;
            ViewBag.bs = bacsi;

            if (bacsi != null)
            {
                DiaChiKham dck = new DiaChiKham();
                ViewBag.dck = null;
                using (var context = new WebDatLichKhamContext())
                {
                    var _bs = bss.FirstOrDefault(x => x.hoten == bacsi);
                    if(_bs != null)
                    {
                        dck = context.DiaChiKhams.FirstOrDefault(x => x.BsId == _bs.mand);
                        if (dck != null)
                        {
                            ViewBag.dck = dck;
                        }
                    }
                }
            }

            DateTime a = DateTime.Now;

            var ngay = db.CaKhams.Where(x => x.Ngaykham >= a.Date).ToList();
            LichKham lichkham = new LichKham();


            if (LKSave.chinhanh != null && LKSave.khoa != null && LKSave.hinhthuc != null)
            {
                LKSave.mand = lichkham.FindMaBS(LKSave.khoa, LKSave.chinhanh, LKSave.bacsi);
                if (LKSave.hinhthuc != null && LKSave.mand != null)
                {
                    ngay = db.CaKhams.Where(x => x.Mand == LKSave.mand && x.Hinhthuc == LKSave.hinhthuc && x.Ngaykham >= a.Date).ToList();
                }

            }


            ViewBag.ngaykham = (from p in ngay select p.Ngaykham.Value.ToString("yyyy-MM-dd")).ToList();
            ViewBag.nk = ngaykham;


            var ca = db.CaKhams.Where(x => x.Ngaykham >= a.Date).ToList();
            if (LKSave.chinhanh != null && LKSave.khoa != null && LKSave.bacsi != null && LKSave.hinhthuc != null && LKSave.ngaykham != null)
            {
                LKSave.mand = lichkham.FindMaBS(LKSave.khoa, LKSave.chinhanh,LKSave.bacsi);

                ca = db.CaKhams.Where(x => x.Mand == LKSave.mand && x.Hinhthuc == LKSave.hinhthuc && (x.Ngaykham).ToString() == LKSave.ngaykham && x.Trangthai == 1).ToList();


            }
            ViewBag.cakham = (from p in ca select (p.Ca)).ToList().Distinct();
            ViewBag.ca = cakham;
            DatLich f = new DatLich();
            f.Ngaydat = DateTime.Now;

            f.Trangthai = 0;

            if (LKSave.chinhanh != null && LKSave.khoa != null && LKSave.bacsi != null && LKSave.hinhthuc != null && LKSave.ngaykham != null && LKSave.cakham != null && LKSave.mand != null && mota != null)
            {
                string bs = (LKSave.ngaykham + "," + LKSave.cakham).ToString();
                LKSave.maca = lichkham.FindMaCa(bs, LKSave.hinhthuc, LKSave.mand);
                f.Maca = LKSave.maca;
                if (u != null)
                {
                    f.Mabn = u.Mabn;
                    if (mota != null)
                    {
                        f.Mota = mota;
                        if (ModelState.IsValid)
                        {
                            int check = db.DatLiches.Where(x => x.Maca == LKSave.maca).Count();
                            if (check == 0)
                            {

                                db.DatLiches.Add(f);
                                db.SaveChanges();

                                return RedirectToAction("Index", "LichKham", new { id = u.Mabn });
                            }
                            else
                            {
                                ViewBag.Fail = "Ca khám này đã có người đặt!";
                                return PartialView();
                            }
                            //db.DatLiches.Add(f);
                            // db.SaveChanges();

                            //   return RedirectToAction("Index", "LichKham", new { id = u.mabn });
                        }
                    }
                }
                else
                {
                    if (mota != null)
                    {
                        f.Mota = mota;

                        return RedirectToAction("NhapTTDK", "LichKham");


                    }
                }
            }
            else
            {
                ViewBag.Fail = "Vui lòng nhập đầy đủ thông tin";
                return PartialView();
            }

            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActionPostData(string hinhthuc, string chinhanh, string khoa, string bacsi, string ngaykham, string cakham, string mota)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userBSJson = httpContext.Session.GetString("user");
            var u = !string.IsNullOrEmpty(userBSJson) ? JsonSerializer.Deserialize<BenhNhan>(userBSJson) : null;
            LKSave.chinhanh = chinhanh;
            LKSave.khoa = khoa;
            LKSave.bacsi = bacsi;
            LKSave.hinhthuc = hinhthuc;
            LKSave.ngaykham = ngaykham;
            LKSave.cakham = cakham;
            LKSave.mota = mota;
            return RedirectToAction("Create", new { hinhthuc = LKSave.hinhthuc, chinhanh = LKSave.chinhanh, khoa = LKSave.khoa, bacsi = LKSave.bacsi, ngaykham = LKSave.ngaykham, cakham = LKSave.cakham, mota = LKSave.mota });
        }

        public ActionResult NhapTTDK()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhapTTDK([Bind("Madat,Ngaydat,Mota,Sdt,Hoten,Ngaysinh,Trangthai,Maca,Mabn")] DatLich f)
        {
            if (f.Sdt != null && f.Hoten != null && f.Ngaysinh != null)
            {

                f.Ngaydat = DateTime.Now;
                f.Mota = LKSave.mota;

                f.Trangthai = 0;
                f.Maca = LKSave.maca;
                if (ModelState.IsValid)
                {
                    int check = db.DatLiches.Where(x => x.Maca == LKSave.maca).Count();
                    if (check == 0)
                    {

                        db.DatLiches.Add(f);
                        db.SaveChanges();

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Fail = "Ca khám này đã có người đặt!";
                        return View();
                    }
                }
            }

            else
            {
                ViewBag.Fail = "Vui lòng nhập đầy đủ thông tin";
                return View(f);
            }

            return View(f);

        }
        public ActionResult DanhGia(int? id, int fi, int madat)
        {
            Bien.mabs = (int)id;
            Bien.mabn = fi;
            DatLich dl = db.DatLiches.Find(madat);
            dl.Trangthai = 4;
            db.Entry(dl).State = EntityState.Modified;
            db.SaveChanges();
            var nd = db.NguoiDungs.Where(h => h.Mand == id).FirstOrDefault();
            var bn = db.BenhNhans.Where(h => h.Mabn == fi).FirstOrDefault();

            ViewBag.mand = nd.Hoten;
            ViewBag.mabn = bn.Tenbn;

            return View();
        }

        // POST: Admin/Tintucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [System.Web.Mvc.ValidateInput(false)]
        public ActionResult DanhGia([Bind("Ngay,Noidung,Mand, Mabn")] DanhGia danhgia)
        {

            if (ModelState.IsValid)
            {
                danhgia.Mabn = Bien.mabn;
                danhgia.Mand = Bien.mabs;
                var d = DateTime.Now;
                danhgia.Ngay = d;
                db.DanhGia.Add(danhgia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mand = new SelectList(db.NguoiDungs, "Mand", "Hoten", danhgia.Mand);
            ViewBag.mabn = new SelectList(db.BenhNhans, "Mabn", "Tenbn", danhgia.Mabn);
            return View(danhgia);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            LichKham ls = new LichKham();
            var lichkham = ls.DSLichKham().Where(x => x.madat == id).FirstOrDefault();
            if (lichkham == null)
            {
                return NotFound();
            }
            return View(lichkham);
        }

        // POST: Lichkham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatLich lichKham = db.DatLiches.Find(id);
            db.DatLiches.Remove(lichKham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
