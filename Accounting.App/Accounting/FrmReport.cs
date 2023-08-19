using AccountingViewModels;
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
        public FrmReport()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            using (DataContext db = new DataContext())
            {
                List<ListCustomersViewModel> list = new List<ListCustomersViewModel>();
                list.Add(new ListCustomersViewModel()
                {
                    CustomerID = 0,
                    FullName = "انتخاب کنید"
                });

                if (list.Any())
                {
                    list.AddRange(db.CustomersRepository.GetCustomerName());
                    cbCustomer.DataSource = list;
                    cbCustomer.DisplayMember = "FullName";
                    cbCustomer.ValueMember = "CustomerID";
                }
            }

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

        public void Filter()
        {
            using (DataContext db = new DataContext())
            {

                List<DataLayer.Accounting> result = new List<DataLayer.Accounting>();



                if ((int)cbCustomer.SelectedValue != 0)
                {
                    int CustomerId = int.Parse(cbCustomer.SelectedValue.ToString());
                    result.AddRange(db.AccountingRepository.Get(a => a.TypeID == TypeID && a.CustomerID == CustomerId));
                }
                else
                {
                    result.AddRange(db.AccountingRepository.Get(a => a.TypeID == TypeID));
                }


                DateTime? startDate;

                if (txtFromDate.Text != "    /  /")
                {
                    startDate = Convert.ToDateTime(txtFromDate.Text);
                    startDate = DateCovertor.ToMiladi(startDate.Value);
                    result = result.Where(r => r.CreateDate >= startDate.Value).ToList();
                }

                DateTime? endDate;

                if (txtToDate.Text != "    /  /")
                {
                    endDate = Convert.ToDateTime(txtToDate.Text);
                    endDate = DateCovertor.ToMiladi(endDate.Value);
                    result.Where(r => r.CreateDate <= endDate.Value).ToList();
                }

                dgReport.Rows.Clear();
                foreach (var item in result)
                {
                    string CustomerName = db.CustomersRepository.GetCustomerNameById(item.CustomerID);
                    dgReport.Rows.Add(item.ID, CustomerName, item.Amount.ToString("#,0"), item.CreateDate.ToShamsi(), item.Description);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (DataContext db = new DataContext())
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
                    db.Dispose();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgReport.CurrentRow != null)
            {
                int AccountId = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
                newfrmAccounting accounting = new newfrmAccounting();
                accounting.AccountingId = AccountId;
                if (accounting.ShowDialog() == DialogResult.OK)
                {
                    Filter();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtPrint = new DataTable();
            dtPrint.Columns.Add("Customer");
            dtPrint.Columns.Add("Amount");
            dtPrint.Columns.Add("CreateDate");
            dtPrint.Columns.Add("Description");
            foreach (DataGridViewRow item in dgReport.Rows)
            {
                dtPrint.Rows.Add(
                item.Cells[1].Value.ToString(),
                item.Cells[2].Value.ToString(),
                item.Cells[3].Value.ToString(),
                item.Cells[4].Value.ToString()
                );
            }

            DataTable DTsum = new DataTable();
            DTsum.Columns.Add("RpSum");

            using (DataContext db = new DataContext())
            {
                float Find = db.AccountingRepository.Get(a => a.TypeID == TypeID).ToList().Sum(a => a.Amount);
                DTsum.Rows.Add(Find.ToString("#,0")+ " تومان");
            }

            StiPrint.Load(Application.StartupPath + "/Report.mrt");
            StiPrint.RegData("DT", dtPrint);
            StiPrint.RegData("DTSum", DTsum);
            StiPrint.Show();

        }
    }
}
