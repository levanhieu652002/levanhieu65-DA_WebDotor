using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppYte.Models
{
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            BaiViets = new HashSet<BaiViet>();
            BenhAns = new HashSet<BenhAn>();
            CaKhams = new HashSet<CaKham>();
            DanhGia = new HashSet<DanhGia>();
            DiaChiKhams = new HashSet<DiaChiKham>();
            HoiDaps = new HashSet<HoiDap>();
        }

        public int Mand { get; set; }
        public string Hoten { get; set; }
        public string Diachi { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Gioitinh { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Chucvu { get; set; }
        public string Hocham { get; set; }
        public string Hocvi { get; set; }
        public string Gioithieu { get; set; }
        public int? Makhoa { get; set; }
        public int? Machinhanh { get; set; }
        public string Tendn { get; set; }
        public string Mk { get; set; }
        public int? Quyen { get; set; }
        public string Anh { get; set; }
        public int? Trangthai { get; set; }

        public virtual ChiNhanh MachinhanhNavigation { get; set; }
        public virtual Khoa MakhoaNavigation { get; set; }
        public virtual ICollection<BaiViet> BaiViets { get; set; }
        public virtual ICollection<BenhAn> BenhAns { get; set; }
        public virtual ICollection<CaKham> CaKhams { get; set; }
        public virtual ICollection<DanhGia> DanhGia { get; set; }
        public virtual ICollection<DiaChiKham> DiaChiKhams { get; set; }
        public virtual ICollection<HoiDap> HoiDaps { get; set; }
    }
}
