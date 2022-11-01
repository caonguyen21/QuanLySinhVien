using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.DataContext;
using QLSV.DataTier;
using QLSV.Libs;
using QLSV.BusinessTier;

namespace QLSV.BusinessTier
{
    class TaiKhoanBT
    {
        private readonly TaiKhoanDT taiKhoanDT;
        public TaiKhoanBT()
        {
            taiKhoanDT = new TaiKhoanDT();
        }
        public TaiKhoan LayTaiKhoan(string tenDangNhap, string matKhau)
        {
            matKhau = Helpers.MaHoaMD5(matKhau);
            return taiKhoanDT.LayTaiKhoan(tenDangNhap, matKhau);
        }

    }
}
