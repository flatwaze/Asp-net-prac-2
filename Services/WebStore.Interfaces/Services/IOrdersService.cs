using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DomainNew.DTO.Orders;
using WebStore.DomainNew.Entities;
using WebStore.Models;

namespace WebStore.Interfaces.Services
{
    public interface IOrdersService
    {
        IEnumerable<OrderDTO> GetUserOrders(string userName);
        OrderDTO GetOrderById(int id);
        OrderDTO CreateOrder(CreateOrderModel orderModel, string userName);
    }
}
