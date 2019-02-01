using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameWorkExample
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnEmpReg_Click(object sender, EventArgs e)
        {
            var frm = new FrmEmpRegister();
            frm.ShowDialog();
        }

        private void btnEmpList_Click(object sender, EventArgs e)
        {
            var frm = new FormEmployeesList();
            frm.ShowDialog();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
