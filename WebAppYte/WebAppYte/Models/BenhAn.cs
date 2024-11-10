using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppYte.Models
{
    public partial class BenhAn
    {
        public int Maba { get; set; }
        public int Mabn { get; set; }
        public int Mabs { get; set; }
        public string Tieude { get; set; }
        public DateTime Ngaykham { get; set; }
        public DateTime Giokham { get; set; }
        public double Mach { get; set; }
        public double Nhietdo { get; set; }
        public double Nhiptho { get; set; }
        public double Chieucao { get; set; }
        public double Cannang { get; set; }
        public double Bmi { get; set; }
        public double Thiluctrai { get; set; }
        public double Thilucphai { get; set; }
        public double NhanapP { get; set; }
        public double NhanapT { get; set; }
        public string Chuandoan { get; set; }
        public string Ketqua { get; set; }
        public int Trangthai { get; set; }

        public virtual BenhNhan MabnNavigation { get; set; }
        public virtual NguoiDung MabsNavigation { get; set; }
    }
}
