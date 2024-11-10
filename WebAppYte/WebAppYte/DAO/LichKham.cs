using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebAppYte.Models;

namespace WebAppYte.DAO
{
    public class LichKham
    {
        public int madat { get; set; }
        public DateTime ngaydat { get; set; }
        public string mota { get; set; }
        public int trangthai { get; set; }
        public int maca { get; set; }
        public int mabn { get; set; }
        public string tenbn { get; set; }
        public DateTime ngaykham { get; set; }
        public string ca { get; set; }
        public string hinhthuc { get; set; }
        public int mand { get; set; }
        public string hoten { get; set; }
        public string sdt { get; set; }
        public DateTime ngaysinh { get; set; }
        public string donthuoc { get; set; }
        public LichKham() { }
        public LichKham(int madat, DateTime ngaydat, DateTime ngaysinh, string mota, int trangthai, int maca, int mabn, string tenbn, string sdt, DateTime ngaykham, string ca, string hinhthuc, int mand, string hoten, string donthuoc)
        {
            this.madat = madat;
            this.ngaydat = ngaydat;
            this.mota = mota;
            this.trangthai = trangthai;
            this.maca = maca;
            this.mabn = mabn;
            this.tenbn = tenbn;
            this.ngaykham = ngaykham;
            this.ca = ca;
            this.hinhthuc = hinhthuc;
            this.mand = mand;
            this.hoten = hoten;
            this.sdt = sdt;
            this.ngaysinh = ngaysinh;
            this.donthuoc = donthuoc;
        }
        public List<LichKham> DSLichKham()
        {

            WebDatLichKhamContext db = new WebDatLichKhamContext();
            
            var lst = (
                           from p in db.DatLiches
                           from x in db.CaKhams
                           from z in db.NguoiDungs

                           where p.Maca == x.Maca && x.Mand == z.Mand /*&& x.Trangthai == 0*/

                           select new LichKham()
                           {
                               madat = p.Madat,
                               ngaydat = (DateTime)p.Ngaydat,
                               mota = p.Mota,
                               trangthai = (int)p.Trangthai,
                               maca = (int)x.Maca,
                               donthuoc = p.Donthuoc,
                               mabn = (int)p.Mabn,

                               tenbn = p.Hoten,
                               ngaysinh = (DateTime)p.Ngaysinh,
                               sdt = p.Sdt,

                               mand = (int)(from q in db.CaKhams
                                            where q.Maca == x.Maca
                                            select new
                                            {
                                                q.Mand
                                            }).FirstOrDefault().Mand,

                               hoten = (from y in db.NguoiDungs

                                        where y.Mand == x.Mand
                                        select new
                                        {
                                            y.Hoten
                                        }).FirstOrDefault().Hoten,
                               ngaykham = (DateTime)(from y in db.CaKhams

                                                     where y.Maca == p.Maca
                                                     select new
                                                     {
                                                         y.Ngaykham
                                                     }).FirstOrDefault().Ngaykham,
                               ca = (from y in db.CaKhams

                                     where y.Maca == p.Maca
                                     select new
                                     {
                                         y.Ca
                                     }).FirstOrDefault().Ca,
                               hinhthuc = (from y in db.CaKhams

                                           where y.Maca == p.Maca
                                           select new
                                           {
                                               y.Hinhthuc
                                           }).FirstOrDefault().Hinhthuc,


                           });


            return lst.ToList();
        }
        public int FindMaCa(string ngaykham = "2022-09-09,Sáng", string hinhthuc = "Khám trong giờ", int mand = 1)
        {
            string[] name = ngaykham.Split(',');
            string ngay = name[0], ca = name[1];
            WebDatLichKhamContext db = new WebDatLichKhamContext();
            int ma = (int)(from y in db.CaKhams

                           where (y.Ngaykham).ToString() == ngay && y.Ca == ca && y.Hinhthuc == hinhthuc && y.Mand == mand
                           select new
                           {
                               y.Maca
                           }).FirstOrDefault().Maca;

            return ma;
        }

        public int FindMaBS(string khoa, string chinhanh, string basi)
        {
            WebDatLichKhamContext db = new WebDatLichKhamContext();

            var res = (from y in db.NguoiDungs
                       from x in db.Khoas
                       from z in db.ChiNhanhs

                       where y.Makhoa == x.Makhoa && y.Machinhanh == z.Machinhanh && x.Tenkhoa == khoa && z.Diachi == chinhanh && y.Hoten == basi
                       select new
                       {
                           y.Mand
                       }).FirstOrDefault();
            int ma = 0;
            if (res != null) ma = res.Mand;
            return ma;
        }
    }
}