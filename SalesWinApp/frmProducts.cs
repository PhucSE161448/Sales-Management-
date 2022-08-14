using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmProducts : Form
    {
        IProductRepository resp = new ProductRepository();
        public frmProducts()
        {
            InitializeComponent();
        }

        private void LoadProductList()
        {
            var proList = resp.GetProducts();
            BindingSource source = new BindingSource();
            source.DataSource = proList;

            dgvProduct.DataSource = null;
            dgvProduct.DataSource = proList;


            lbTitle.Text = "Products Managerment";
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            LoadProductList();

        }

        public Product GetProduct()
        {
            Product product = null;
            try
            {
                int index = dgvProduct.CurrentCell.RowIndex;
                var dummy = (Product)dgvProduct.Rows[index].DataBoundItem;
                product = resp.GetProductID(dummy.ProductId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return product;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmProductDetail frmProductDetail = new frmProductDetail
            {
                Text = "Create Product",
                InsertOrUpdate = false,
                PRepository = resp,

            };
            if (frmProductDetail.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult d;
                d = MessageBox.Show("Do you really want to delete this record?", "Product Management",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);

                if (d == DialogResult.OK)
                {
                    var productID = GetProduct();
                    resp.DeleteProduct(productID);
                    LoadProductList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var pID = resp.GetProductID(int.Parse(txtProductID.Text));
                BindingSource source = new BindingSource();
                source.DataSource = pID;
                dgvProduct.DataSource = null;
                dgvProduct.DataSource = source;
                if (txtProductID.Text == "")
                {
                    LoadProductList();
                }
            }
            catch (Exception ex) { }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var pName = resp.GetProductsName(txtProductName.Text);
                BindingSource source = new BindingSource();
                source.DataSource = pName;
                dgvProduct.DataSource = null;
                dgvProduct.DataSource = source;
            }
            catch (Exception ex) { }
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmProductDetail frmProductDetail = new frmProductDetail
            {
                Text = "Update Producr",
                InsertOrUpdate = true,
                ProductInfor = GetProduct(),
                PRepository = resp,
            };
            if (frmProductDetail.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
            }
        }

        private void txtUnitsInStock_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var unitStock = resp.GetUnitStock(int.Parse(txtUnitsInStock.Text));
                BindingSource source = new BindingSource();
                source.DataSource = unitStock;
                dgvProduct.DataSource = null;
                dgvProduct.DataSource = source;
            }
            catch (Exception ex) { }
        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var unitPrice = resp.GetUnitPrice(decimal.Parse(txtUnitPrice.Text));
                BindingSource source = new BindingSource();
                source.DataSource = unitPrice;
                dgvProduct.DataSource = null;
                dgvProduct.DataSource = source;
            }
            catch (Exception ex) { }
        }
    }
}
