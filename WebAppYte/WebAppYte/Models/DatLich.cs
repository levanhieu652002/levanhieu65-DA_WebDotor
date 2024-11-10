using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppYte.Models
{
    public partial class DatLich
    {
        public int Madat { get; set; }
        public DateTime? Ngaydat { get; set; }
        public string Mota { get; set; }
        public string Sdt { get; set; }
        public string Hoten { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public int? Trangthai { get; set; }
        public int? Maca { get; set; }
        public int? Mabn { get; set; }
        public string Donthuoc { get; set; }

        public virtual CaKham MacaNavigation { get; set; }
    }
}
