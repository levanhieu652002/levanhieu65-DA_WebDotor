using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WebAppYte.Models;

namespace WebAppYte.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebDatLichKhamContext db;
        public HomeController(WebDatLichKhamContext context)
        {
            db = context;
        }

        public ActionResult index()
        {
            return View();

        }

        public ActionResult Trangchu()
        {
            return View();

        }

        [HttpGet]
        public ActionResult Dangky()
        {
            ViewBag.gioitinh = new string[] { "Nam", "Nữ" };
            return View();
        }

        // POST: Admin/NguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dangky([Bind("Mabn,Tenbn,Sdt,Email,Diachi,Ngaysinh,Gioitinh,Tendn,Mk")] BenhNhan benhnhan)
        {
            if (ModelState.IsValid)
            {
                int check = db.BenhNhans.Count(x => x.Tendn == benhnhan.Tendn);
                if (check == 0)
                {
                    db.BenhNhans.Add(benhnhan);
                    db.SaveChanges();
                    string benhnhanJson = JsonConvert.SerializeObject(benhnhan);
                    HttpContext.Session.SetString("benhnhan", benhnhanJson);
                    return RedirectToAction("Dangnhap");
                }
                else
                {
                    ViewBag.gioitinh = new string[] { "Nam", "Nữ" };
                    ViewBag.loi = "Tên đăng nhập đã tồn tại!";
                    return View(benhnhan);
                }
            }

            ViewBag.gioitinh = new string[] { "Nam", "Nữ" };
            return View(benhnhan);
        }

        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(IFormCollection Dangnhap)
        {
            string tk = Dangnhap["tendn"].ToString();
            string mk = Dangnhap["mk"].ToString();
            var islogin = db.BenhNhans.Where(x => x.Trangthai == 1).SingleOrDefault(x => x.Tendn.Equals(tk) && x.Mk.Equals(mk));
            var isloginAdmin = db.NguoiDungs.Where(x => x.Trangthai == 1).SingleOrDefault(x => x.Tendn.Equals(tk) && x.Mk.Equals(mk));
            if (islogin != null)
            {
                string userJson = JsonConvert.SerializeObject(islogin);
                HttpContext.Session.SetString("user", userJson);
                return RedirectToAction("Details", "BenhNhan", new { id = @islogin.Mabn });

            }
            else if (isloginAdmin != null && isloginAdmin.Quyen == 0)
            {
                string userAdminJson = JsonConvert.SerializeObject(isloginAdmin);
                HttpContext.Session.SetString("userAdmin", userAdminJson);
                return RedirectToAction("HomeAdmin", "Admin");
            }
            else if (isloginAdmin != null && isloginAdmin.Quyen == 1)
            {
                string userBSJson = JsonConvert.SerializeObject(isloginAdmin);
                HttpContext.Session.SetString("userBS", userBSJson);
                return RedirectToAction("Trangchu", "Home");
            }
            else
            {
                ViewBag.Fail = "Tài khoản hoặc mật khẩu không chính xác.";
                return View("Dangnhap");
            }

        }
        public class listofSegments
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }


        public ActionResult DangXuat()
        {
            string userJson = JsonConvert.SerializeObject(null);
            HttpContext.Session.SetString("user", userJson);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DangXuatBs()
        {
            string userBSJson = JsonConvert.SerializeObject(null);
            HttpContext.Session.SetString("userBS", userBSJson);
            return RedirectToAction("Index", "Home");
        }
    }
}
