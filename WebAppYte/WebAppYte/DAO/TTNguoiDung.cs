using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppYte.Models;
namespace WebAppYte.DAO
{
    public class TTNguoiDung
    {
        public int mand { get; set; }
        public string hoten { get; set; }
        public string chucvu { get; set; }
        public string hocham { get; set; }
        public string hocvi { get; set; }
        public string gioithieu { get; set; }
        public string tenkhoa { get; set; }
        public string tenchinhanh { get; set; }
        public string anh { get; set; }
        public string tendn { get; set; } 

        public TTNguoiDung() { }
        public TTNguoiDung(int mand, string hoten, string chucvu, string hocham, string hocvi, string gioithieu, string tenkhoa, string tenchinhanh, string anh, string tendn)
        {
            this.mand = mand;
            this.hoten = hoten;
            this.chucvu = chucvu;
            this.hocham = hocham;
            this.hocvi = hocvi;
            this.gioithieu = gioithieu;
            this.tenkhoa = tenkhoa;
            this.tenchinhanh = tenchinhanh;
            this.anh = anh;
            this.tendn = tendn;
        }
        public List<TTNguoiDung> ListNguoiDung()
        {
            WebDatLichKhamContext db = new WebDatLichKhamContext();
            var lst = (
                           from p in db.NguoiDungs
                           from x in db.Khoas
                           from t in db.ChiNhanhs
                           where p.Makhoa == x.Makhoa && p.Machinhanh==t.Machinhanh
                          
                           select new TTNguoiDung()
                           {
                               mand = p.Mand,
                               hoten = p.Hoten,
                               chucvu = p.Chucvu,
                               hocham = p.Hocham,
                               hocvi = p.Hocvi,
                               gioithieu=p.Gioithieu,
                               anh=p.Anh,
                               tendn=p.Tendn,
                               tenkhoa = ((from z in db.Khoas
                                          where z.Makhoa == p.Makhoa
                                          select new
                                          {
                                              z.Tenkhoa
                                          }).FirstOrDefault().Tenkhoa),

                               tenchinhanh = (from y in db.ChiNhanhs

                                      where y.Machinhanh == p.Machinhanh
                                      select new
                                      {
                                          y.Diachi
                                      }).FirstOrDefault().Diachi,
                           });

            return lst.ToList();
        }

    }
       
  
}