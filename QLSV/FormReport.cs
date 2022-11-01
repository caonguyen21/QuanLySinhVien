using Microsoft.Reporting.WinForms;
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
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
            QLSVModel1 context = new QLSVModel1();
        }
        public List<ReportChapVa> ConvertToReport(List<Student> students)
        {
            List<ReportChapVa> listReport = new List<ReportChapVa>();
            for (int i = 0; i < students.Count; i++)
            {
                ReportChapVa temp = new ReportChapVa();
                temp.Stt += i; 
                temp.Mssv = students[i].StudentID;
                temp.Hoten = students[i].FullName;
                temp.Dtb = students[i].AverageScore;
                temp.Khoa = students[i].Faculty.FacultyName;
                listReport.Add(temp);
            }
            return listReport;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            QLSVModel1 context = new QLSVModel1();
            this.reportViewer1.LocalReport.ReportPath = "Report2.rdlc";
            var reportDataSource = new ReportDataSource("DataSet1", ConvertToReport(context.Students.ToList()));
            this.reportViewer1.LocalReport.DataSources.Clear();  //clear
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
