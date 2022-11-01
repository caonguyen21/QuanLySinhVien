using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSV.BusinessTier;
using QLSV.DataContext;

namespace QLSV
{
    public delegate void DangNhapThanhCong();
    public partial class FrmDangNhap : Form
    {
        private TaiKhoanBT taiKhoanBT;
        public FrmDangNhap()
        {
            InitializeComponent();
            taiKhoanBT = new TaiKhoanBT(); 
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản!");
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            TaiKhoan taiKhoan = taiKhoanBT.LayTaiKhoan(tenDangNhap, matKhau);
            if (taiKhoan != null)
            {
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                frmQuanLySinhVien frmsv = new frmQuanLySinhVien();
                frmsv.Show();
            }
            else
            {
                MessageBox.Show("Sai thông tin đăng nhập!");
                return;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
