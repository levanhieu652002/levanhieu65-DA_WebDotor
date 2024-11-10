using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppYte.Models
{
    public partial class DiaChiKham
    {
        public int Id { get; set; }
        public int BsId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public virtual NguoiDung Bs { get; set; }
    }
}
