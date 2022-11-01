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
    public partial class frmQuanLySinhVien : Form
    {
        QLSVModel1 contextDB;
        public frmQuanLySinhVien()
        {
            InitializeComponent();
            contextDB = new QLSVModel1();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Student> listStudent = contextDB.Students.ToList();
            List<Faculty> listFaculty = contextDB.Faculties.ToList();
            DoDuLieuStudent(listStudent);
            DoDuLieuKhoaVien(listFaculty);
        }

        private void DoDuLieuKhoaVien(List<Faculty> list)
        {
            cbbKhoaVien.DataSource = list;
            cbbKhoaVien.DisplayMember = "FacultyName";
            cbbKhoaVien.ValueMember = "FacultyID";
        }

        private void DoDuLieuStudent(List<Student> list)
        {
            dgvQuanLy.Rows.Clear();
            foreach (var item in list)
            {
                int indexRow = dgvQuanLy.Rows.Add(); //add một dòng mới
                dgvQuanLy.Rows[indexRow].Cells[0].Value = item.StudentID;
                dgvQuanLy.Rows[indexRow].Cells[1].Value = item.FullName;
                dgvQuanLy.Rows[indexRow].Cells[2].Value = item.Faculty.FacultyName;
                dgvQuanLy.Rows[indexRow].Cells[3].Value = item.AverageScore;
            }
        }

        private void dgvQuanLy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvQuanLy.Rows[e.RowIndex].Cells[e.ColumnIndex] != null)
                {
                    dgvQuanLy.CurrentRow.Selected = true;

                    txtMSSV.Text = dgvQuanLy.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtHoTen.Text = dgvQuanLy.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtDTB.Text = dgvQuanLy.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    cbbKhoaVien.SelectedIndex = cbbKhoaVien.FindString(dgvQuanLy.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ô bạn chọn không hợp lệ, vui chọn lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text == "" || txtHoTen.Text == "" || cbbKhoaVien.Text == "" || txtDTB.Text == "")
            {
                MessageBox.Show("Thông tin nhập vào chưa đúng!!!", "Thông Báo");
                txtMSSV.Focus();
            }
            else if (txtMSSV.TextLength < 10 || txtMSSV.TextLength > 10)
            {
                MessageBox.Show("Mã số sinh viên gồm 10 ký tự, vui lòng nhập lại", "Thông Báo");
                return;
            }
            Student db = contextDB.Students.FirstOrDefault(p => p.StudentID == txtMSSV.Text);
            Student s = new Student();
            if (db == null)
            {
                if (cbbKhoaVien.Text == "Công nghệ thông tin")
                {
                    s.StudentID = txtMSSV.Text;
                    s.FullName = txtHoTen.Text;
                    s.AverageScore = double.Parse(txtDTB.Text);
                    s.FacultyID = 1;
                    contextDB.Students.Add(s);
                    contextDB.SaveChanges();
                }
                else if (cbbKhoaVien.Text == "Quản trị kinh doanh")
                {
                    s.StudentID = txtMSSV.Text;
                    s.FullName = txtHoTen.Text;
                    s.AverageScore = double.Parse(txtDTB.Text);
                    s.FacultyID = 2;
                    contextDB.Students.Add(s);
                    contextDB.SaveChanges();
                }
                else
                {
                    s.StudentID = txtMSSV.Text;
                    s.FullName = txtHoTen.Text;
                    s.AverageScore = double.Parse(txtDTB.Text);
                    s.FacultyID = 3;
                    contextDB.Students.Add(s);
                    contextDB.SaveChanges();
                }
                List<Student> listStudent = contextDB.Students.ToList();
                DoDuLieuStudent(listStudent);
                MessageBox.Show("Thêm sinh viên vào danh sách thành công", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Đã có sinh viên này trong danh sách", "Thông Báo", MessageBoxButtons.OK);
            }

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            Student db = contextDB.Students.FirstOrDefault(p => p.StudentID == txtMSSV.Text);
            if (db != null)
            {
                if (cbbKhoaVien.Text == "Công nghệ thông tin")
                {
                    db.StudentID = txtMSSV.Text;
                    db.FullName = txtHoTen.Text;
                    db.AverageScore = double.Parse(txtDTB.Text);
                    db.FacultyID = 1;
                    contextDB.SaveChanges();
                }
                else if (cbbKhoaVien.Text == "Quản trị kinh doanh")
                {
                    db.StudentID = txtMSSV.Text;
                    db.FullName = txtHoTen.Text;
                    db.AverageScore = double.Parse(txtDTB.Text);
                    db.FacultyID = 2;
                    contextDB.SaveChanges();
                }
                else
                {
                     db.StudentID = txtMSSV.Text;
                     db.FullName = txtHoTen.Text;
                     db.AverageScore = double.Parse(txtDTB.Text);
                     db.FacultyID = 3;
                     contextDB.SaveChanges();
                }
                List<Student> listStudent = contextDB.Students.ToList();
                DoDuLieuStudent(listStudent);
                MessageBox.Show("Cập nhật dữ liệu cho sinh viên thành công", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Không tìm thấy MSSV cần sửa thông tin", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Student db = contextDB.Students.FirstOrDefault(p => p.StudentID == txtMSSV.Text);
            if (db != null)
            {
                DialogResult check = MessageBox.Show("Bạn có chắc sẽ xóa sinh viên ra khỏi danh sách chứ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (check == DialogResult.Yes)
                {
                    contextDB.Students.Remove(db);
                    contextDB.SaveChanges();
                    MessageBox.Show("Xóa sinh viên thành công", "Thông Báo", MessageBoxButtons.OK);
                    List<Student> listStudent = contextDB.Students.ToList();
                    DoDuLieuStudent(listStudent);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhoaVien kv = new frmKhoaVien();
            kv.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmKhoaVien kv = new frmKhoaVien();
            kv.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn muốn thoát phần mềm?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
                this.Close();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiem tk = new frmTimKiem();
            tk.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmTimKiem tk = new frmTimKiem();
            tk.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn muốn thoát phần mềm?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
                this.Close();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            FormReport rp = new FormReport();
            rp.Show();
        }
    }
}
