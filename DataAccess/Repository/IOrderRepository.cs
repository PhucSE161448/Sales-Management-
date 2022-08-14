using BusinessObject.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetOrder();
        void SaveOrder(Order o);
        void UpdateOrder(Order o);
        void DeleteOrder(Order o);
        Order GetOrderID(int id);
        List<Order> RequiredDate(DateTime date1, DateTime date2);


    }
}
