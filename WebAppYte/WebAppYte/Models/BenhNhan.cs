using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppYte.Models
{
    public partial class BenhNhan
    {
        public BenhNhan()
        {
            BenhAns = new HashSet<BenhAn>();
            DanhGia = new HashSet<DanhGia>();
            HoiDaps = new HashSet<HoiDap>();
        }

        public int Mabn { get; set; }
        public string Tenbn { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Gioitinh { get; set; }
        public string Tendn { get; set; }
        public string Mk { get; set; }
        public int? Trangthai { get; set; }

        public virtual ICollection<BenhAn> BenhAns { get; set; }
        public virtual ICollection<DanhGia> DanhGia { get; set; }
        public virtual ICollection<HoiDap> HoiDaps { get; set; }
    }
}
