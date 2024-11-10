using ImageProcessor.Processors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAppYte.Models;

namespace WebAppYte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChiNhanhController : Controller
    {
        private readonly WebDatLichKhamContext _context;

        public ChiNhanhController(WebDatLichKhamContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ChiNhanh> list = _context.ChiNhanhs.ToList();

            return View(list);
        }

        public IActionResult Edit(int id)
        {
            ChiNhanh c = _context.ChiNhanhs.FirstOrDefault(x => x.Machinhanh == id);
            return View(c);
        }

        [HttpPost]
        public IActionResult Edit( ChiNhanh chiNhanh)
        {
            if (ModelState.IsValid)
            {
                ChiNhanh c = _context.ChiNhanhs.FirstOrDefault(x=> x.Machinhanh  == chiNhanh.Machinhanh);
                c.Diachi = chiNhanh.Diachi;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            ChiNhanh c = _context.ChiNhanhs.FirstOrDefault(x => x.Machinhanh == id);
            _context.ChiNhanhs.Remove(c);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ChiNhanh chiNhanh)
        {
            if (ModelState.IsValid)
            {
                _context.ChiNhanhs.Add(chiNhanh);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
