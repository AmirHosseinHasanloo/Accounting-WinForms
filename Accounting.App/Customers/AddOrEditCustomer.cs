using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Accounting.App
{
    public partial class AddOrEditCustomer : Form
    {
        public int CustomerId = 0;
        DataContext db = new DataContext();
        public AddOrEditCustomer()
        {
            InitializeComponent();
        }

        private void AddOrEditCustomer_Load(object sender, EventArgs e)
        {
            if (CustomerId == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else
            {
                this.Text = "ویرایش اطلاعات شخص";
                Customer customers = db.CustomersRepository.GetCustomersByID(CustomerId);
                txtName.Text = customers.FullName;
                txtEmail.Text = customers.Email;
                txtMobile.Text = customers.Mobile;
                txtAddress.Text = customers.Address;
                pcCustomer.ImageLocation = Application.StartupPath + "/CustomersImage/" + customers.CustomerImage;
                btnSelectPhoto.Text = "ویرایش تصویر";
            }
        }
        private void btnSelectPhoto_MouseClick(object sender, MouseEventArgs e)
        {
            if (btnSelectPhoto.Text != "ویرایش تصویر")
            {
                OpenFileDialog OpenFile = new OpenFileDialog();

                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    pcCustomer.ImageLocation = OpenFile.FileName;
                }
            }
            else
            {
                OpenFileDialog OpenFile = new OpenFileDialog();
                var Customer = db.CustomersRepository.GetCustomersByID(CustomerId);
                System.IO.File.Delete(Application.StartupPath + "/CustomersImage/" + Customer.CustomerImage);
                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    pcCustomer.ImageLocation = OpenFile.FileName;
                }
            }

        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CustomerId == 0)
            {
                if (BaseValidator.IsFormValid(this.components))
                {
                    if (btnSelectPhoto.Text != "ویرایش تصویر")
                    {
                        string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(pcCustomer.ImageLocation);
                        string ImagePath = Application.StartupPath + "/CustomersImage/";
                        Directory.CreateDirectory(ImagePath);
                        pcCustomer.Image.Save(ImagePath + ImageName);

                        //Insert to db here 
                        Customer customer = new Customer();
                        customer.FullName = txtName.Text;
                        customer.Mobile = txtMobile.Text;
                        customer.Email = txtEmail.Text;
                        customer.Address = txtAddress.Text;
                        customer.CustomerImage = ImageName;
                        db.CustomersRepository.InsertCustomer(customer);
                        db.Save();
                    }
                }
            }
            else if (CustomerId != 0)
            {
                Customer customers = db.CustomersRepository.GetCustomersByID(CustomerId);
                customers.FullName = txtName.Text;
                customers.Email = txtEmail.Text;
                customers.Mobile = txtMobile.Text;
                customers.Address = txtAddress.Text;
                pcCustomer.ImageLocation = Application.StartupPath + "/CustomersImage/" + customers.CustomerImage;

                // Change Picture              
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(pcCustomer.ImageLocation);
                    string ImagePath = Application.StartupPath + "/CustomersImage/";
                    pcCustomer.Image.Save(ImagePath + ImageName);
                    customers.CustomerImage = ImageName;
                // Update 
                db.CustomersRepository.UpdateCustomer(customers);
                db.Save();
            }
            DialogResult = DialogResult.OK;

        }
    }
}
