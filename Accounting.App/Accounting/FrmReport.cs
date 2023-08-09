using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App
{
    public partial class FrmReport : Form
    {
        public int TypeID = 0;
        DataContext db = new DataContext();
        public FrmReport()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            if (TypeID == 1)
            {
                this.Text = "گزارش دریافت";
            }
            else
            {
                this.Text = "گزارش پرداخت";
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }

        void Filter()
        {

            var result = db.AccountingRepository.Get(a => a.TypeID == TypeID);
            dgReport.AutoGenerateColumns = false;
            //dgReport.DataSource = result;
            dgReport.Rows.Clear();
            foreach (var item in result)
            {
                string CustomerName = db.CustomersRepository.GetCustomerNameById(item.CustomerID);
                dgReport.Rows.Add(item.ID, CustomerName, item.Amount.ToString("#,0"), item.CreateDate.ToShamsi(), item.Description);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgReport.CurrentRow != null)
            {
                if (RtlMessageBox.Show("آیا از حذف کردن این طرف حساب اطمینان دارید", "توجه", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
                    db.AccountingRepository.Delete(id);
                    db.Save();
                    Filter();
                }
            }
        }
    }
}
