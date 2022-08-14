using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmMemberDetail : Form
    {
        public frmMemberDetail()
        {
            InitializeComponent();
        }

        private void ClearText()
        {
            txtMemberID.Text = "";
            txtEmail.Text = "";
            txtCmName.Text = "";
            txtCountry.Text = "";
            txtCity.Text = "";
            txtPassword.Text = "";

        }

        public IMemberRepository MRepository { get; set; }
        public bool InsertOrUpdate { get; set; }//False: Insert, True: Update
        public Member MemberInfor { get; set; }

        private void frmMemberDetail_Load(object sender, System.EventArgs e)
        {
            txtMemberID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                lbTitle.Text = "Update Member";
                txtMemberID.Text = MemberInfor.MemberId.ToString();
                txtEmail.Text = MemberInfor.Email;
                txtCmName.Text = MemberInfor.CompanyName;
                txtCountry.Text = MemberInfor.Country;
                txtCity.Text = MemberInfor.City;
                txtPassword.Text = MemberInfor.Password;
            }
            else
            {
                lbTitle.Text = "Create Member";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var m = new Member()
                {
                    MemberId = int.Parse(txtMemberID.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCmName.Text,
                    Country = txtCountry.Text,
                    City = txtCity.Text,
                    Password = txtPassword.Text
                };
                if (InsertOrUpdate)
                {
                    MRepository.UpdateMember(m);
                }
                else
                {
                    MRepository.SaveMember(m);
                    ClearText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new member" : "Update a member");
            }

        }

        private void button1_Click(object sender, EventArgs e) => Close();
    }
}
