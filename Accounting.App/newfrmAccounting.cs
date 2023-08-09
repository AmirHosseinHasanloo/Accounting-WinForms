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
    public partial class newfrmAccounting : Form
    {
        DataContext db = new DataContext();
        public newfrmAccounting()
        {
            InitializeComponent();
        }

        private void newfrmAccounting_Load(object sender, EventArgs e)
        {
            dgCustomers.AutoGenerateColumns = false;
            dgCustomers.DataSource = db.CustomersRepository.GetCustomerName();
        }

        private void txtFillter_TextChanged(object sender, EventArgs e)
        {
            dgCustomers.DataSource = db.CustomersRepository.GetCustomerName(txtFillter.Text);
        }
    }
}
