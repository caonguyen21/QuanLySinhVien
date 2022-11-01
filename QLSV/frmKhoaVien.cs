using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSV.DataContext;

namespace QLSV
{
    public partial class frmKhoaVien : Form
    {
        QLSVModel1 contextDB;
        public frmKhoaVien()
        {
            InitializeComponent();
            contextDB = new QLSVModel1();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            List<Faculty> listFaculty = contextDB.Faculties.ToList();
            DonDuLieuFaculty(listFaculty);
        }

        private void DonDuLieuFaculty(List<Faculty> list)
        {
            dgvKhoaVien.Rows.Clear();
            foreach (var item in list)
            {
                int indexRow = dgvKhoaVien.Rows.Add();
                dgvKhoaVien.Rows[indexRow].Cells[0].Value = item.FacultyID.ToString();
                dgvKhoaVien.Rows[indexRow].Cells[1].Value = item.FacultyName.ToString();
                dgvKhoaVien.Rows[indexRow].Cells[2].Value = item.TotalProfessor.ToString();
            }
        }
        private void dgvKhoaVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKhoaVien.Rows[e.RowIndex].Cells[e.ColumnIndex] != null)
                {
                    dgvKhoaVien.CurrentRow.Selected = true;
                    txtMaKhoa.Text = dgvKhoaVien.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtTenKhoa.Text = dgvKhoaVien.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtTongGS.Text = dgvKhoaVien.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ô bạn chọn không hợp lệ, vui chọn lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text == "" || txtTenKhoa.Text == "" || txtTongGS.Text == "")
            {
                MessageBox.Show("Thông tin nhập vào chưa đúng!!!", "Thông Báo");
                txtMaKhoa.Focus();
                return;
            }
            Faculty db = contextDB.Faculties.FirstOrDefault(p => p.FacultyID.ToString() == txtMaKhoa.Text);
            Faculty s = new Faculty();
            if (db == null)
            {
                s.FacultyID = int.Parse(txtMaKhoa.Text.ToString());
                s.FacultyName = txtTenKhoa.Text;
                s.TotalProfessor = int.Parse(txtTongGS.Text);
                contextDB.Faculties.Add(s);
                contextDB.SaveChanges();
                List<Faculty> listFaculty = contextDB.Faculties.ToList();
                DonDuLieuFaculty(listFaculty);
                MessageBox.Show("Thêm khoa viện thành công", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                db.FacultyID = int.Parse(txtMaKhoa.Text);
                db.FacultyName = txtTenKhoa.Text;
                db.TotalProfessor = int.Parse(txtTongGS.Text);
                contextDB.SaveChanges();
                List<Faculty> listFaculty = contextDB.Faculties.ToList();
                DonDuLieuFaculty(listFaculty);
                MessageBox.Show("Cập nhật khoa viện thành công", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Faculty db = contextDB.Faculties.FirstOrDefault(p => p.FacultyID.ToString() == txtMaKhoa.Text);
            if (db != null)
            {
                DialogResult check = MessageBox.Show("Bạn có chắc sẽ xóa khoa ra khỏi danh sách chứ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    contextDB.Faculties.Remove(db);
                    contextDB.SaveChanges();
                    MessageBox.Show("Xóa khoa viện thành công", "Thông Báo", MessageBoxButtons.OK);
                    List<Faculty> listFaculty = contextDB.Faculties.ToList();
                    DonDuLieuFaculty(listFaculty);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khoa viện cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn muốn thoát khỏi trang quản lý khoa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
                this.Close();
        }
    }
}
