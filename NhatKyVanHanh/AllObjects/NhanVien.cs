using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NhatKyVanHanh.AllObjects
{
    class NhanVien
    {

        /*[Id]          NVARCHAR (50) NOT NULL,
    [MaKip]       NVARCHAR (50) NOT NULL,
    [TenNhanVien] NVARCHAR (50) NOT NULL,
    [KipTruong]   NVARCHAR (50) NULL,*/
        public string maNv { get; set; }
        public string maKip { get; set; }
        public string tenNV { get; set; }
        public string kipTruong { get; set; }

    }
}
