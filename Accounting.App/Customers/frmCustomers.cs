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
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        void BindGrid()
        {
            using (DataContext db = new DataContext())
            {
                dgCustomers.DataSource = db.CustomersRepository.GetAllCustomers();
            }
        }

        private void btnRefreshCustomers_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            BindGrid();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            BindGrid();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            using (DataContext db = new DataContext())
            {
                dgCustomers.DataSource = db.CustomersRepository.SearchCustomers(txtFilter.Text);
            }
        }

        private void btnDeleteCustomers_Click(object sender, EventArgs e)
        {
            if (dgCustomers.CurrentRow != null)
            {
                using (DataContext db = new DataContext())
                {
                    string Name = dgCustomers.CurrentRow.Cells[1].Value.ToString();

                    if (RtlMessageBox.Show($"آیا از حذف {Name} مطمئن هستید ؟", "!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int CustomerId = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());
                        // find customer for delete image
                        var DeleteCustomerPicture = db.CustomersRepository.GetCustomersByID(CustomerId);
                        System.IO.File.Delete(Application.StartupPath + "/CustomersImage/" + DeleteCustomerPicture.CustomerImage);
                        db.CustomersRepository.DeleteCustomer(CustomerId);
                        db.SaveChanges();
                        BindGrid();
                    }
                }
            }
            else
            {
                RtlMessageBox.Show("لطفا یک شخص را انتخاب کنید", "!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddCustomers_Click(object sender, EventArgs e)
        {
            AddOrEditCustomer frm = new AddOrEditCustomer();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnEditCustomers_Click(object sender, EventArgs e)
        {
            if (dgCustomers.CurrentRow != null)
            {
                int CustomerId = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());
                AddOrEditCustomer frm = new AddOrEditCustomer();
                frm.CustomerId = CustomerId;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک شخص را انتخاب کنید", "!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
    }
}
