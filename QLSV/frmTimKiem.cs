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
    public partial class frmTimKiem : Form
    {
        QLSVModel1 contextDB;
        public frmTimKiem()
        {
            InitializeComponent();
            contextDB = new QLSVModel1();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtKetQua.Text = "0";
            List<Faculty> listFacculty = contextDB.Faculties.ToList();
            DoDuLieuKhoaVien(listFacculty);

        }
        private void DoDuLieuStudent(List<Student> list)
        {
            dgvTimKiem.Rows.Clear();
            foreach (var item in list)
            {
                int indexRow = dgvTimKiem.Rows.Add();
                dgvTimKiem.Rows[indexRow].Cells[0].Value = item.StudentID;
                dgvTimKiem.Rows[indexRow].Cells[1].Value = item.FullName;
                dgvTimKiem.Rows[indexRow].Cells[2].Value = item.Faculty.FacultyName;
                dgvTimKiem.Rows[indexRow].Cells[3].Value = item.AverageScore;
            }
        }
        private void DoDuLieuKhoaVien(List<Faculty> list)
        {
            cbbKhoaVien.DataSource = list;
            cbbKhoaVien.DisplayMember = "FacultyName";
            cbbKhoaVien.ValueMember = "FacultyID";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMSSV.Text == "" || txtHoTen.Text == "" || cbbKhoaVien.Text == "")
            {
                MessageBox.Show("Thông tin nhập vào chưa đúng!!!", "Thông Báo");
                txtMSSV.Focus();
                return;
            }
            List<Student> listStudent = contextDB.Students.ToList();
            List<Student> listFindStudent = (from s in listStudent
                                             where
                       s.StudentID == txtMSSV.Text ||
                       s.FullName == txtHoTen.Text ||
                       s.Faculty.FacultyID == Convert.ToInt32(cbbKhoaVien.SelectedValue)
                                             select s).ToList();
            txtKetQua.Text = (listFindStudent.Count).ToString();
            DoDuLieuStudent(listFindStudent);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMSSV.Text = "";
            txtHoTen.Text = "";
            txtKetQua.Text = "0";
            cbbKhoaVien.SelectedIndex = 0;
            dgvTimKiem.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn muốn thoát khỏi trang tìm kiếm?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
                this.Close();
        }
    }
}
