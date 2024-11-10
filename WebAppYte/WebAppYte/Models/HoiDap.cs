using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppYte.Models
{
    public partial class HoiDap
    {
        public int Ma { get; set; }
        public string Hoi { get; set; }
        public DateTime? Ngayhoi { get; set; }
        public DateTime? Ngaytl { get; set; }
        public string Dap { get; set; }
        public int? Mand { get; set; }
        public int? Mabn { get; set; }
        public int? Trangthai { get; set; }

        public virtual BenhNhan MabnNavigation { get; set; }
        public virtual NguoiDung MandNavigation { get; set; }
    }
}
