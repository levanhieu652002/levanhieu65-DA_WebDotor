using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppYte.Models
{
    public partial class Loai
    {
        public Loai()
        {
            BaiViets = new HashSet<BaiViet>();
        }

        public int Maloai { get; set; }
        public string Tenloai { get; set; }

        public virtual ICollection<BaiViet> BaiViets { get; set; }
    }
}
