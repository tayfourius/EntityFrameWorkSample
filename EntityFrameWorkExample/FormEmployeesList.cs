using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Repository;

namespace EntityFrameWorkExample
{
    public partial class FormEmployeesList : Form
    {
        public ClsRepository<Employee> EmpRep { get; set; }
        public ClsRepository<Gender> GenRep { get; set; }
       
        public FormEmployeesList()
        {
            InitializeComponent();
        }

        //تعبئة الجريد فيو
        private void PopulateDataGrid()
        {

            var employyName = string.IsNullOrEmpty(txtName.Text)? "" : txtName.Text;
            var employeeid = string.IsNullOrEmpty(txtID.Text) ? "" : txtID.Text;

            var datasource =
                EmpRep.GetAll()
                    .Select(
                        x =>
                            new
                            {
                                x.ID ,
                                x.Emp_Name,
                                x.Emp_ID,
                                x.Gender.Gender1,
                                BirthDate = x.Emp_BirthDay?.Date.ToString("yyyy/MM/dd"),
                                x.Emp_Phone,
                                Salary = x.Emp_Salary?.ToString("0.0")//لعرض خانة واحدة فقط من الخانات العشرية
                            })
                            .Where(x => x.Emp_Name.Contains(employyName) && x.Emp_ID.Contains(employeeid) )
                            .ToList();

            dgv.DataSource = datasource;

            dgv.Columns[0].Visible = false; //لاخفاء العمود الأول

            dgv.Columns[1].HeaderText = "إسم الموظف";
            dgv.Columns[2].HeaderText = "رقم الهوية";
            dgv.Columns[3].HeaderText = "الجنس";
            dgv.Columns[4].HeaderText = "تاريخ الميلاد";
            dgv.Columns[5].HeaderText = "الهاتف";
            dgv.Columns[6].HeaderText = "الراتب";

            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FormEmployeesList_Load(object sender, EventArgs e)
        {
            EmpRep = new ClsRepository<Employee>();
            GenRep = new ClsRepository<Gender>();

            PopulateDataGrid();
        }

        private void Searching(object sender, EventArgs e)
        {
            PopulateDataGrid();
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            var tid = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);

            var frm = new FrmEmpRegister(tid);
            frm.ShowDialog();

            FormEmployeesList_Load(sender , e);
        }
    }
}
