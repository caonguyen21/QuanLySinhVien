using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.DataContext;

namespace QLSV.DataTier
{
    class TaiKhoanDT
    {
        public TaiKhoan LayTaiKhoan(string tenDangNhap, string matKhau)
        {
            using (var dbContext = new QLSVModel1())
            {
                return dbContext.TaiKhoans.Where(s => s.TenDangNhap ==
                tenDangNhap && s.MatKhau == matKhau).FirstOrDefault();
            }
        }
    }
}
