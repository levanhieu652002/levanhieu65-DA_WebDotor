
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAppYte.DAO;
using WebAppYte.Models;
using WebAppYte.wwwroot.Common;
using X.PagedList;

namespace WebAppYte.Controllers
{
    public class ChuyenGiaBacSiController : Controller
    {
        private readonly WebDatLichKhamContext db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ChuyenGiaBacSiController(WebDatLichKhamContext context, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: Trungtamyte
        public ActionResult Index()
        {         
            return View();
        }
        public ActionResult TintucHotPartial()
        {

            return PartialView();

        }
        public class listofSegments
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }
        public PartialViewResult ChuyenGiaBacSi(string id, string tencv, int page = 1)
        {
            TTNguoiDung nd = new TTNguoiDung();
            id = Bien.str;
            int pageSize = 5;

            List<string> segmentList = db.Khoas.Select(p => p.Tenkhoa).ToList();

            ViewBag.segmentList = segmentList;
            ViewBag.filter = id;

            var chucvu = new List<listofSegments>();
            listofSegments segmentItem;
            var strArr = new string[] { "Giám đốc", "Phó giám đốc", "Trưởng khoa", "Phó trưởng khoa", "Bác sĩ" };

            for (int index = 0; index < strArr.Length; index++)
            {
                segmentItem = new listofSegments();
                segmentItem.Text = strArr[index];
                segmentItem.Value = strArr[index];
                chucvu.Add(segmentItem);
            }
            ViewBag.chucvu = chucvu;
            ViewBag.choose = tencv;



            var list = db.Khoas.ToList();
            var nguoi_dung = nd.ListNguoiDung();


            if (list.Exists(x => x.Tenkhoa == id) == true)
            {

                nguoi_dung = nguoi_dung.Where(x => x.tenkhoa == id).ToList();
            }

            if (tencv != null)
            {

                nguoi_dung = nguoi_dung.Where(x => x.chucvu != null && x.chucvu.ToLower().Contains(tencv.ToLower())).ToList();
            }

            var model = nguoi_dung.OrderBy(x => x.hoten).ToPagedList(page, pageSize);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult ActionPostData(string filter, string tencv)
        {
            Bien.str = filter;
            Bien.tencv = tencv;
            return RedirectToAction("ChuyenGiaBacSi", new { id = Bien.str, tencv = Bien.tencv });
        }
        public PartialViewResult Search(string id, string tencv, string filter, int page = 1)
        {
            TTNguoiDung nd = new TTNguoiDung();
            filter = Bien.str;
            int pageSize = 5;

            List<string> segmentList = (from p in db.Khoas select p.Tenkhoa).ToList();
            ViewBag.segmentList = segmentList;
            ViewBag.filter = filter;

            var chucvu = new List<listofSegments>();
            listofSegments segmentItem;
            var strArr = new string[] { "Giám đốc", "Phó giám đốc", "Trưởng khoa", "Phó trưởng khoa", "Bác sĩ" };

            for (int index = 0; index < strArr.Length; index++)
            {
                segmentItem = new listofSegments();
                segmentItem.Text = strArr[index];
                segmentItem.Value = strArr[index];
                chucvu.Add(segmentItem);
            }
            ViewBag.chucvu = chucvu;
            ViewBag.choose = tencv;

            Bien.tk = id;
            ViewBag.id = Bien.tk;
            ViewBag.txt = Bien.tk;

            if (Bien.tk == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var nguoi_dung = nd.ListNguoiDung().Where(x => x.hoten.ToLower().Contains(Bien.tk.ToLower()) || x.gioithieu.ToLower().Contains(Bien.tk.ToLower())).ToList();

            var list = db.Khoas.ToList();


            if (list.Exists(x => x.Tenkhoa == filter) == true)
            {

                nguoi_dung = nguoi_dung.Where(x => x.tenkhoa == filter).ToList();
            }

            if (tencv != null)
            {

                nguoi_dung = nguoi_dung.Where(x => x.chucvu.ToLower().Contains(tencv.ToLower())).ToList();
            }

            var model = nguoi_dung.OrderBy(x => x.hoten).ToPagedList(page, pageSize);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult ActionSearch(string filter, string tencv)
        {

            Bien.str = filter;
            Bien.tencv = tencv;
            return RedirectToAction("Search/" + ViewBag.txt, new { });
        }

        public ActionResult HaNoi(string id, string tencv, int page = 1)
        {
            TTNguoiDung nd = new TTNguoiDung();
            id = Bien.str;
            int pageSize = 5;

            List<string> segmentList = (from p in db.Khoas select p.Tenkhoa).ToList();
            ViewBag.segmentList = segmentList;
            ViewBag.filter = id;

            var chucvu = new List<listofSegments>();
            listofSegments segmentItem;
            var strArr = new string[] { "Giám đốc", "Dược sĩ", "Cố vẫn chuyên môn", "Trưởng khoa", "Phó khoa", "Bác sĩ" };

            for (int index = 0; index < strArr.Length; index++)
            {
                segmentItem = new listofSegments();
                segmentItem.Text = strArr[index];
                segmentItem.Value = strArr[index];
                chucvu.Add(segmentItem);
            }
            ViewBag.chucvu = chucvu;
            ViewBag.choose = tencv;



            var list = db.Khoas.ToList();
            var nguoi_dung = nd.ListNguoiDung();


            if (list.Exists(x => x.Tenkhoa == id) == true)
            {

                nguoi_dung = nguoi_dung.Where(x => x.tenkhoa == id).ToList();
            }

            if (tencv != null)
            {

                nguoi_dung = nguoi_dung.Where(x => x.chucvu.ToLower().Contains(tencv.ToLower())).ToList();
            }

            var model = nguoi_dung.Where(x => x.tenchinhanh == "Hà Nội").ToPagedList(page, pageSize);
            return View(model);
        }

        public ActionResult DaNang(string id, string tencv, int page = 1)
        {
            TTNguoiDung nd = new TTNguoiDung();
            id = Bien.str;
            int pageSize = 5;

            List<string> segmentList = (from p in db.Khoas select p.Tenkhoa).ToList();
            ViewBag.segmentList = segmentList;
            ViewBag.filter = id;

            var chucvu = new List<listofSegments>();
            listofSegments segmentItem;
            var strArr = new string[] { "Giám đốc", "Dược sĩ", "Cố vẫn chuyên môn", "Trưởng khoa", "Phó khoa", "Bác sĩ" };

            for (int index = 0; index < strArr.Length; index++)
            {
                segmentItem = new listofSegments();
                segmentItem.Text = strArr[index];
                segmentItem.Value = strArr[index];
                chucvu.Add(segmentItem);
            }
            ViewBag.chucvu = chucvu;
            ViewBag.choose = tencv;



            var list = db.Khoas.ToList();
            var nguoi_dung = nd.ListNguoiDung();


            if (list.Exists(x => x.Tenkhoa == id) == true)
            {

                nguoi_dung = nguoi_dung.Where(x => x.tenkhoa == id).ToList();
            }

            if (tencv != null)
            {

                nguoi_dung = nguoi_dung.Where(x => x.chucvu.ToLower().Contains(tencv.ToLower())).ToList();
            }
            var model = nguoi_dung.Where(x => x.tenchinhanh == "Đà Nẵng").ToPagedList(page, pageSize);
            return View(model);
        }

        public ActionResult SaiGon(string id, string tencv, int page = 1)
        {
            TTNguoiDung nd = new TTNguoiDung();
            id = Bien.str;
            int pageSize = 5;

            List<string> segmentList = (from p in db.Khoas select p.Tenkhoa).ToList();
            ViewBag.segmentList = segmentList;
            ViewBag.filter = id;

            var chucvu = new List<listofSegments>();
            listofSegments segmentItem;
            var strArr = new string[] { "Giám đốc", "Dược sĩ", "Cố vẫn chuyên môn", "Trưởng khoa", "Phó khoa", "Bác sĩ" };

            for (int index = 0; index < strArr.Length; index++)
            {
                segmentItem = new listofSegments();
                segmentItem.Text = strArr[index];
                segmentItem.Value = strArr[index];
                chucvu.Add(segmentItem);
            }
            ViewBag.chucvu = chucvu;
            ViewBag.choose = tencv;



            var list = db.Khoas.ToList();
            var nguoi_dung = nd.ListNguoiDung();


            if (list.Exists(x => x.Tenkhoa == id) == true)
            {

                nguoi_dung = nguoi_dung.Where(x => x.tenkhoa == id).ToList();
            }

            if (tencv != null)
            {

                nguoi_dung = nguoi_dung.Where(x => x.chucvu.ToLower().Contains(tencv.ToLower())).ToList();
            }

            var model = nguoi_dung.Where(x => x.tenchinhanh == "Sài Gòn").ToPagedList(page, pageSize);
            return View(model);
        }
        public ActionResult DatLichHen(string id)
        {
            TTNguoiDung nd = new TTNguoiDung();
            var nguoi_dung = nd.ListNguoiDung();
            int mand = int.Parse(id);
            var model = nguoi_dung.Find(x => x.mand == mand);
         
            return View(model);
        }

        public ActionResult Details(int id)
        {
          /*  if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            TrungTamGanNhat tt = db.TrungTamGanNhats.Find(id);
            if (tt == null)
            {
                return HttpNotFound();
            } */
            return View();
        }
        public ViewResult van()
        {
            return View();
        }
      
    }

    
}