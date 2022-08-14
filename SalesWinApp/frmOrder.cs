using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmOrder : Form
    {
        IOrderRepository _repository = new OrderRepository();
        public frmOrder()
        {
            InitializeComponent();
        }

        public void ListOrder()
        {
            var list = _repository.GetOrder();
            BindingSource source = new BindingSource();
            source.DataSource = list;

            dgvOrder.DataSource = null;
            dgvOrder.DataSource = list;
        }

        public Order getOrder()
        {
            Order o = null;
            try
            {
                int index = dgvOrder.CurrentCell.RowIndex;
                var dummy = (Order)dgvOrder.Rows[index].DataBoundItem;
                o = _repository.GetOrderID(dummy.OrderId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return o;
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            ListOrder();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Do you really want to delete this record?", "Order Management",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);

            if (d == DialogResult.OK)
            {
                var OrderID = getOrder();
                _repository.DeleteOrder(OrderID);
                ListOrder();
            }
        }
    }
}
