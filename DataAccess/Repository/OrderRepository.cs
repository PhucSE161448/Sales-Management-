using BusinessObject.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(Order o)
        => OrderDAO.DeleteOrder(o);
        public List<Order> GetOrder()
        => OrderDAO.GetOrder();

        public Order GetOrderID(int id)
        => OrderDAO.GetOrderID(id);

        public List<Order> RequiredDate(DateTime date1, DateTime date2)
        => OrderDAO.RequiredDate(date1, date2);

        public void SaveOrder(Order o)
        => OrderDAO.SaveOrder(o);

        public void UpdateOrder(Order o)
        => OrderDAO.UpdateOrder(o);
    }
}
