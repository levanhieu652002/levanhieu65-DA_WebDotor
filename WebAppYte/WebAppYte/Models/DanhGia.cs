using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppYte.Models
{
    public partial class DanhGia
    {
        public int Madanhgia { get; set; }
        public DateTime? Ngay { get; set; }
        public string Noidung { get; set; }
        public int? Mand { get; set; }
        public int? Mabn { get; set; }

        public virtual BenhNhan MabnNavigation { get; set; }
        public virtual NguoiDung MandNavigation { get; set; }
    }
}
