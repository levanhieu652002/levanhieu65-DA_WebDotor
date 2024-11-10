using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppYte.Models
{
    public partial class Khoa
    {
        public Khoa()
        {
            NguoiDungs = new HashSet<NguoiDung>();
        }

        public int Makhoa { get; set; }
        public string Tenkhoa { get; set; }
        public string Mota { get; set; }

        public virtual ICollection<NguoiDung> NguoiDungs { get; set; }
    }
}
