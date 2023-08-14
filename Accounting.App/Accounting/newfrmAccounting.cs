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
using ValidationComponents;

namespace Accounting.App
{
    public partial class newfrmAccounting : Form
    {
        private DataContext db;
        public int AccountingId = 0;
        public newfrmAccounting()
        {
            InitializeComponent();
        }

        private void newfrmAccounting_Load(object sender, EventArgs e)
        {
            db = new DataContext();
            dgCustomers.AutoGenerateColumns = false;
            dgCustomers.DataSource = db.CustomersRepository.GetCustomerName();
            if (AccountingId != 0)
            {
                var account = db.AccountingRepository.GetById(AccountingId);
                txtAmount.Text = account.Amount.ToString();
                txtDescription.Text = account.Description.ToString();
                txtName.Text = db.CustomersRepository.GetCustomerNameById(account.CustomerID).ToString();
                if (account.TypeID == 1)
                {
                    rbRecive.Checked = true;
                }
                else
                {
                    rbPay.Checked = true;
                }
                this.Text = "ویرایش";
                btnSubmit.Text = "ویرایش";
            }
            db.Dispose();
        }

        private void txtFillter_TextChanged(object sender, EventArgs e)
        {
            dgCustomers.DataSource = db.CustomersRepository.GetCustomerName(txtFillter.Text);
        }

        private void dgCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgCustomers.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            db = new DataContext();
            if (BaseValidator.IsFormValid(this.components))
            {
                if (rbPay.Checked || rbRecive.Checked)
                {
                    DataLayer.Accounting accounting = new DataLayer.Accounting()
                    {
                        Amount = int.Parse(txtAmount.Value.ToString()),
                        CreateDate = DateTime.Now,
                        Description = txtDescription.Text,
                        CustomerID = db.CustomersRepository.GetCumtomerIdByName(txtName.Text),
                        TypeID = (rbRecive.Checked) ? 1 : 2,
                    };
                    if (AccountingId == 0)
                    {
                        db.AccountingRepository.Insert(accounting);
                        db.Save();
                    }
                    else
                    {
                        accounting.ID = AccountingId;
                        db.AccountingRepository.Update(accounting);
                    }
                    db.Save();
                    db.Dispose();
                    DialogResult = DialogResult.OK;

                }
                else
                {
                    RtlMessageBox.Show("لطفا نوع تراکنش را مشخص کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}
