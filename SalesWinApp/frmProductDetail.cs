using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmProductDetail : Form
    {
        public IProductRepository PRepository { get; set; }
        public bool InsertOrUpdate { get; set; }//False: Insert, True: Update
        public Product ProductInfor { get; set; }
        public frmProductDetail()
        {
            InitializeComponent();
        }

        private void ClearText()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtUnitPrice.Text = "";
            txtUnitsInStock.Text = "";
            txtWeight.Text = "";
            cboCategoryName.SelectedIndex = 0;
        }

        private void LoadCategoriesList()
        {
            try
            {
                var catList = PRepository.GetCategories();
                cboCategoryName.DataSource = catList;
                cboCategoryName.ValueMember = "CategoryId";
                cboCategoryName.DisplayMember = "CategoryName";

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error load list Categories");
            }
        }

        private void frmProductDetail_Load(object sender, EventArgs e)
        {
            LoadCategoriesList();
            txtProductID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                lbTitle.Text = "Update Member";
                txtProductID.Text = ProductInfor.ProductId.ToString();
                txtProductName.Text = ProductInfor.ProductName;
                txtUnitPrice.Text = ProductInfor.UnitPrice.ToString();
                txtUnitsInStock.Text = ProductInfor.UnitsInStock.ToString();
                txtWeight.Text = ProductInfor.Weight;
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
                int catName = 0;
                if (cboCategoryName.Text.Equals("Food")) catName = 1;
                else if (cboCategoryName.Text.Equals("Drink")) catName = 2;
                var product = new Product()
                {
                    ProductId = int.Parse(txtProductID.Text),
                    ProductName = txtProductName.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitsInStock = int.Parse(txtUnitsInStock.Text),
                    Weight = txtWeight.Text,
                    CategoryId = catName,
                };
                if (InsertOrUpdate)
                {
                    PRepository.UpdateProduct(product);
                }
                else
                {
                    PRepository.SaveProduct(product);
                    ClearText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new Product" : "Update a Product");
            }
        }

        private void button1_Click(object sender, EventArgs e) => Close();


    }
}
