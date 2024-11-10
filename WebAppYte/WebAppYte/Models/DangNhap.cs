using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppYte.Models
{
    public partial class DangNhap
    {
        public int Ma { get; set; }
        public string Tendn { get; set; }
        public string Mk { get; set; }
        public int? Quyen { get; set; }
        public int? Mand { get; set; }
    }
}
