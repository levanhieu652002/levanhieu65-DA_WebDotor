using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppYte.Models;
namespace WebAppYte.DAO
{
    public class ListHoiDap
    {
        public int ma { get; set; }
        public string hoi { get; set; }
        public DateTime ngayhoi { get; set; }
        public string dap { get; set; }
        public DateTime ngaytl { get; set; }
        public int mand { get; set; }
        public string hoten{ get; set; }
        public int mabn { get; set; }
        public string tenbn { get; set; }
        public int trangthai { get; set; }

        public ListHoiDap() { }
        public ListHoiDap(int ma, string hoi, DateTime ngayhoi, string dap, DateTime ngaytl, int mand, string hoten, int mabn, string tenbn, int trangthai)
        {
            this.ma = ma;
            this.hoi = hoi;
            this.ngayhoi = ngayhoi;
            this.dap= dap;
            this.ngaytl = ngaytl;
            this.mand= mand;
            this.mabn = mabn;
            this.tenbn= tenbn;
            this.trangthai = trangthai;
            this.hoten = hoten;
          
        }
        public List<ListHoiDap> DSHoiDap()
        {
            WebDatLichKhamContext db = new WebDatLichKhamContext();
            var lst = (
                           from p in db.HoiDaps
                           from x in db.NguoiDungs
                           from t in db.BenhNhans
                           where p.Mand == x.Mand && p.Mabn == t.Mabn

                           select new ListHoiDap()
                           {
                               ma = p.Ma,
                               hoi = p.Hoi,
                               ngayhoi =(DateTime)p.Ngayhoi,
                               dap = p.Dap,
                               ngaytl = (DateTime)p.Ngaytl,
                               mand = (int)p.Mand,
                               mabn =(int) p.Mabn,
                               trangthai = (int)p.Trangthai,
                               hoten = ((from z in db.NguoiDungs
                                           where z.Mand == p.Mand
                                           select new
                                           {
                                               z.Hoten
                                           }).FirstOrDefault().Hoten),

                               tenbn = (from y in db.BenhNhans

                                              where y.Mabn == p.Mabn
                                              select new
                                              {
                                                  y.Tenbn
                                              }).FirstOrDefault().Tenbn,
                           }).ToList();

            return lst;
        }
    }
}