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
        DataContext db = new DataContext();
        public int AccountingId = 0;
        ICustomersRepository customersRepository;
        public newfrmAccounting()
        {
            InitializeComponent();
            customersRepository = new CustomersRepository(db);
        }

        private void newfrmAccounting_Load(object sender, EventArgs e)
        {
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
            if (BaseValidator.IsFormValid(this.components))
            {
                if (rbPay.Checked || rbRecive.Checked)
                {
                    DataLayer.Accounting accounting = new DataLayer.Accounting()
                    {
                        Amount = int.Parse(txtAmount.Value.ToString()),
                        CreateDate = DateTime.Now,
                        Description = txtDescription.Text,
                        CustomerID = customersRepository.GetCumtomerIdByName(txtName.Text),
                        TypeID = (rbRecive.Checked) ? 1 : 2,
                    };
                    if (AccountingId == 0)
                    {
                        db.AccountingRepository.Insert(accounting);
                    }
                    if (AccountingId != 0)
                    {
                        accounting.ID = AccountingId;
                        db.AccountingRepository.Update(accounting);
                    }
                    db.Save();
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
