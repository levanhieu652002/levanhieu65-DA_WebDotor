using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppYte.Models
{
    public partial class BaiViet
    {
        public int Mabv { get; set; }
        public string Tieude { get; set; }
        public string Noidung { get; set; }
        public string Hinhanh { get; set; }
        public string Mota { get; set; }
        public DateTime? Ngaydang { get; set; }
        public int? Maloai { get; set; }
        public int? Mand { get; set; }

        public virtual Loai MaloaiNavigation { get; set; }
        public virtual NguoiDung MandNavigation { get; set; }
    }
}
