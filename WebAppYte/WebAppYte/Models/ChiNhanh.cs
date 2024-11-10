using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppYte.Models
{
    public partial class ChiNhanh
    {
        public ChiNhanh()
        {
            NguoiDungs = new HashSet<NguoiDung>();
        }

        public int Machinhanh { get; set; }
        public string Diachi { get; set; }

        public virtual ICollection<NguoiDung> NguoiDungs { get; set; }
    }
}
