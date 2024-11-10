using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.Json;
using WebAppYte.DAO;
using WebAppYte.Models;
using X.PagedList;

namespace WebAppYte.Controllers
{
    public class BacsiController : Controller
    {
        private readonly WebDatLichKhamContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BacsiController(WebDatLichKhamContext context, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Bacsi
        public ActionResult Index()
        {
            var quanTris = db.NguoiDungs.Include(q => q.MakhoaNavigation).Where(x => x.Quyen == 1);
            return View(quanTris.ToList());
        }


        // GET: Bacsi/Details/5
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
        // GET: Bacsi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest() ;
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
                return RedirectToAction("Details", "BacSi", new { id = quanTri.Mand });
            }
            ViewBag.makhoa = new SelectList(db.Khoas, "Makhoa", "Tenkhoa", quanTri.Makhoa);
            ViewBag.machinhanh = new SelectList(db.ChiNhanhs, "Machinhanh", "Diachi", quanTri.Machinhanh);

            return View(quanTri);
        }



        public ActionResult Quanlyhoidap(int? page)
        {
            if (page == null) page = 1;
            var hoiDaps = db.HoiDaps.Include(h => h.MabnNavigation).Include(h => h.MandNavigation).Where(n => n.Trangthai == 0).OrderByDescending(a => a.Ngayhoi).ThenBy(a => a.Ma).ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(hoiDaps.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Traloicauhoi(int? id)
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
            ViewBag.mabn = new SelectList(db.BenhNhans, "Mabn", "Tenbn", hoiDap.Mabn);
            ViewBag.mand = new SelectList(db.NguoiDungs, "Mand", "Tendn", hoiDap.Mand);
            return View(hoiDap);
        }

        // POST: Hoidap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Traloicauhoi(int ma, string hoi, string dap, int mabn)
        {
            if (ModelState.IsValid)
            {
                var httpContext = _httpContextAccessor.HttpContext;
                var userBSJson = httpContext.Session.GetString("userBS");
                var userBS = !string.IsNullOrEmpty(userBSJson) ? JsonSerializer.Deserialize<NguoiDung>(userBSJson) : null;

                HoiDap hoiDap = db.HoiDaps.Find(ma);
                hoiDap.Ngaytl = DateTime.Now;
                hoiDap.Mand = userBS.Mand; ;
                hoiDap.Dap = dap;
                hoiDap.Trangthai = 1;
                db.Entry(hoiDap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Quanlyhoidap");
            }

            return View();
        }

        public ActionResult Kiemtralichhen(int id, int? page)
        {
            LichKham lichkham = new LichKham();
            var lich = lichkham.DSLichKham().Where(x => x.mand == id).OrderByDescending(x => x.ngaykham).ThenBy(y => y.madat).ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.id = id;
            return View(lich.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Lichdangcho(int id, int? page)
        {
            LichKham lichkham = new LichKham();
            var lich = lichkham.DSLichKham().OrderByDescending(x => x.ngaykham).ThenBy(y => y.madat).Where(x => x.trangthai == 0 && x.mand == id).ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(lich.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Lichdaxacnhan(int id, int? page)
        {
            LichKham lichkham = new LichKham();
            var lich = lichkham.DSLichKham().OrderByDescending(x => x.ngaykham).ThenBy(y => y.madat).Where(x => x.trangthai == 1 && x.mand == id).ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(lich.ToPagedList(pageNumber, pageSize));
        }

        // GET: Lichkham/Edit/5
        public ActionResult Xacnhanlichhen(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            LichKham ls = new LichKham();

            LichKham lichKham = ls.DSLichKham().Where(x => x.madat == id).FirstOrDefault();
            if (lichKham == null)
            {
                return NotFound();
            }
            // NguoiDung n = new NguoiDung();
            ViewBag.mabn = new SelectList(db.BenhNhans.Where(x => x.Mabn == lichKham.mabn), "Mabn", "Tenbn", lichKham.mabn);
            ViewBag.hoten = ls.tenbn;
            ViewBag.ngaykham = lichKham.ngaykham.ToString("dd/MM/yyyy");
            ViewBag.mand = new SelectList(db.NguoiDungs.Where(x => x.Mand == lichKham.mand), "Mand", "Hoten", lichKham.mand);
            return View(lichKham);
        }

        // POST: Lichkham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Xacnhanlichhen([Bind("madat,mota,ca,hinhthuc,trangthai,tenbn, mand,donthuoc")] LichKham lichKham, string ngaykham)
        {
            DateTime ngay = DateTime.ParseExact(ngaykham,"dd/MM/yyyy",null);
            lichKham.ngaykham = ngay;
            if (ModelState.IsValid)
            {
                DatLich ls = db.DatLiches.Find(lichKham.madat);
                ls.Trangthai = lichKham.trangthai;
                ls.Donthuoc = lichKham.donthuoc;
                db.Entry(ls).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Kiemtralichhen", "Bacsi", new { id = lichKham.mand });
            }
            ViewBag.mabn = new SelectList(db.BenhNhans, "Mabn", "Tenbn", lichKham.mabn);
            ViewBag.mand = new SelectList(db.NguoiDungs, "Mand", "Hoten", lichKham.mand);
            ViewBag.hoten = lichKham.tenbn;
            return View(lichKham);
        }

        public ActionResult Comment(int? id)
        {

            var danhgia = db.DanhGia.Include(h => h.MabnNavigation).Include(h => h.MandNavigation).Where(h => h.Mand == id).OrderByDescending(a => a.Ngay).ThenBy(a => a.Madanhgia).ToList();

            return PartialView(danhgia);
        }

        public ActionResult DiaChiKham(int bsId)
        {
            using(var context = new WebDatLichKhamContext())
            {
                DiaChiKham dck = context.DiaChiKhams.FirstOrDefault(x=> x.BsId == bsId);
                if (dck == null)
                {
                    DiaChiKham _dck = new DiaChiKham();
                    _dck.BsId = bsId;
                    return View(_dck);
                }
                return View(dck);
            }
        }

        [HttpPost]
        public ActionResult DiaChiKham(DiaChiKham dck)
        {
            using(var context = new WebDatLichKhamContext())
            {
                if(dck.Id == 0)
                {
                    context.DiaChiKhams.Add(dck);
                }
                else
                {
                    DiaChiKham _dck = context.DiaChiKhams.FirstOrDefault(x=> x.Id == dck.Id);
                    _dck.Name = dck.Name;
                    _dck.Address = dck.Address;
                }
                var result = context.SaveChanges();
            }
            return RedirectToAction("Details", new {id =  dck.BsId});
        }

        public ActionResult Lichsukham(int bnId,int bsId, int? page)
        {
            LichKham ls = new LichKham();
            var lichKhams = ls.DSLichKham().Where(h => h.mabn == bnId && h.mand == bsId).OrderByDescending(x => x.ngaydat).ThenBy(x => x.madat);
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
