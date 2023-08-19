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
    public partial class frmLogin : Form
    {
        public bool IsEdit = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (IsEdit == true)
            {
                btnLogin.Text = "ویرایش";
                this.Text = "ویرایش اطلاعات ورود";
                using (DataContext db = new DataContext())
                {
                    txtUserName.Text = db.LoginTypesRepository.Get().First().UserName;
                    txtPassword.Text = db.LoginTypesRepository.Get().First().Password;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                using (DataContext db = new DataContext())
                {
                    if (IsEdit == true)
                    {
                        var User = db.LoginTypesRepository.Get().First();
                        User.UserName = txtUserName.Text;
                        User.Password = txtPassword.Text;

                        db.LoginTypesRepository.Update(User);
                        db.Save();
                        RtlMessageBox.Show("کاربر گرامی اطلاعات حساب شما با موفقیت بروز رسانی شد", "توجه");
                        Application.Restart();
                    }
                    else
                    {
                        if (db.LoginTypesRepository.Get(u => u.UserName == txtUserName.Text && u.Password == txtPassword.Text).Any())
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            RtlMessageBox.Show("کاربری با این مشخصات وجود ندارد", "توجه");
                        }
                    }
                }
            }
        }
    }
}
