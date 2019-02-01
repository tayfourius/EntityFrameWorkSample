using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repository;
using DAL;

namespace EntityFrameWorkExample
{
    public partial class FrmEmpRegister : Form
    {
        public ClsRepository<Employee> EmpRep { get; set; }
        public ClsRepository<Gender> GenRep { get; set; }
        public int? TransferedId { get; set; }

        public int? Id { get; set; }

        public FrmEmpRegister()
        {
            InitializeComponent();
        }

        public FrmEmpRegister(int? empid)
        {
            InitializeComponent();
            TransferedId = empid;
        }

        //تعبئة الكومبوبوكس
        private void PopulateComboBox()
        {
            var datasource = GenRep.GetAll();
            comboGender.DataSource = datasource;

            comboGender.DisplayMember = "Gender1";
            comboGender.ValueMember = "ID";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmEmpRegister_Load(object sender, EventArgs e)
        {
            EmpRep = new ClsRepository<Employee>();
            GenRep = new ClsRepository<Gender>();
            groupBox1.Enabled = false;

            PopulateComboBox();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Id = null;
            ResetForm();
            groupBox1.Enabled = btnDelete.Enabled = true;
            btnNew.Enabled = false;
            txtName.Focus();
        }

        private void ResetForm()
        {
            txtID.Text = txtName.Text = txtPhone.Text = txtSalary.Text = string.Empty;
            comboGender.SelectedIndex = -1;
            dateOfBirth.ResetText();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("الرجاء من ادخال كافة بيانات الموظف ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Id.Equals(null))
            {
                var addedempl = new Employee
                {
                    Emp_Name = txtName.Text,
                    Emp_ID = txtID.Text,
                    Gender_ID = Convert.ToInt32(comboGender.SelectedValue.ToString()),
                    Emp_BirthDay = dateOfBirth.Value.Date,
                    Emp_Phone = txtPhone.Text,
                    Emp_Salary = Convert.ToDecimal(txtSalary.Text)
                };

                EmpRep.Add(addedempl);
                Id = addedempl.ID;
                MessageBox.Show("تم الحفظ بنجاح ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.None);


            }
            else
            {
                var updatedempl = new Employee
                {
                    ID = (int)Id,
                    Emp_Name = txtName.Text,
                    Emp_ID = txtID.Text,
                    Gender_ID = Convert.ToInt32(comboGender.SelectedValue.ToString()),
                    Emp_BirthDay = dateOfBirth.Value.Date,
                    Emp_Phone = txtPhone.Text,
                    Emp_Salary = Convert.ToDecimal(txtSalary.Text)
                };

                EmpRep.Update(updatedempl , Id);
                MessageBox.Show("تم التعديل بنجاح ", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.None);
            }


            btnNew.Enabled = btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (Id == null)
            {
                MessageBox.Show("لا يوجد موظف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (MessageBox.Show("هل ترغب بإتمام عملية الحذف ؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EmpRep.DeleteById(Id);
                ResetForm();
                MessageBox.Show("تم الحذف بنجاح ", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        
        //لاستخدام زر الانتر بدل زر التاب للتنقل
        private void Use_EnterKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        //لادخال الارقام فقط داخل التكست بوكس
        private void EnterNumberEvent(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        //استقبال البيانات المرسلة من فورم لائحة الموظفين
        private void FrmEmpRegister_Shown(object sender, EventArgs e)
        {
            if (TransferedId != null)
            {

                groupBox1.Enabled = true;

                var newemployee = EmpRep.Get(TransferedId);

                Id = newemployee.ID;
                txtName.Text = newemployee.Emp_Name;
                txtID.Text = newemployee.Emp_ID;
                comboGender.Text = newemployee.Gender.Gender1;
                dateOfBirth.Text = newemployee.Emp_BirthDay.ToString();
                txtPhone.Text = newemployee.Emp_Phone;
                txtSalary.Text = string.Format("{0:0.0}", newemployee.Emp_Salary);
            }
        }
    }
}
