using DataAccess.Repository;
using MyStoreWinApp;
using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                IMemberRepository resm = new MemberRepository();
                string fileName = "appsettings.json";
                string json = File.ReadAllText(fileName);  // đọc text từ tập tin JSON
                var member = resm.GetMember(txtEmail.Text, txtPassword.Text);
                // deserialize từ chuỗi đọc ở tập tin JSOn --> đối tượng DefaultAccount
                var adminAccount = JsonSerializer.Deserialize<DefaultAccount>(json, null);

                string emailA = adminAccount.Email;
                string passwordA = adminAccount.Password;

                if (txtEmail.Text.Equals(emailA) && txtPassword.Text.Equals(passwordA))
                {
                    frmMain main = new frmMain();
                    main.ShowDialog();
                    Close();
                }
                else if (member != null)
                {
                    frmMain main = new frmMain();
                    main.ShowDialog();
                    Close();

                }
                else
                {
                    MessageBox.Show("Incorect Email Password!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtEmail.Text = "";
        }
    }
}
