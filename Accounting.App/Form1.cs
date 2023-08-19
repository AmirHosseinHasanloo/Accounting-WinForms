using Accounting.Bussiness;
using AccountingViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCustumers_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            frm.ShowDialog();
        }

        private void btnNewAccounting_Click(object sender, EventArgs e)
        {
            newfrmAccounting newfrmAccounting = new newfrmAccounting();
            newfrmAccounting.ShowDialog();
        }

        private void btnReportPay_Click(object sender, EventArgs e)
        {
            FrmReport frmReport = new FrmReport();
            frmReport.TypeID = 2;
            frmReport.ShowDialog();
        }

        private void btnReportRecive_Click(object sender, EventArgs e)
        {
            FrmReport frmReport = new FrmReport();
            frmReport.TypeID = 1;
            frmReport.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            BindGrid();
            frmLogin frmLog = new frmLogin();
            if (frmLog.ShowDialog() == DialogResult.OK)
            {
                tsDate.Text = DateTime.Now.ToShamsi();
                tsClock.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                Application.Exit();
            }
        }

        void BindGrid()
        {
            ReportMonth();
            ReportDay();
            ReportYear();
        }

        void ReportMonth()
        {
            ReportViewModel report = Account.ReportMonth();
            lblRecive.Text = report.Recive.ToString("#,0");
            lblPay.Text = report.Pay.ToString("#,0");
            lblBalance.Text = report.Balance.ToString("#,0");
        }
        void ReportDay()
        {
            ReportViewModel report = Account.ReportDay();
            lblReciveDay.Text = report.Recive.ToString("#,0");
            lblPayDay.Text = report.Pay.ToString("#,0");
            lblBalanceDay.Text = report.Balance.ToString("#,0");
        }

        void ReportYear()
        {
            ReportViewModel report = Account.ReportYear();
            lblReciveYear.Text = report.Recive.ToString("#,0");
            lblPayYear.Text = report.Pay.ToString("#,0");
            lblBalanceYear.Text = report.Balance.ToString("#,0");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tsClock.Text = " " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnEditLogin_Click(object sender, EventArgs e)
        {
            frmLogin frmLog = new frmLogin();
            frmLog.IsEdit = true;
            frmLog.ShowDialog();
        }

        private void btnBindGrid_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}
