using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppYte.Models
{
    public partial class CaKham
    {
        public CaKham()
        {
            DatLiches = new HashSet<DatLich>();
        }

        public int Maca { get; set; }
        public DateTime? Ngaykham { get; set; }
        public string Hinhthuc { get; set; }
        public string Ca { get; set; }
        public int? Mand { get; set; }
        public int? Trangthai { get; set; }

        public virtual NguoiDung MandNavigation { get; set; }
        public virtual ICollection<DatLich> DatLiches { get; set; }
    }
}
