using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.DomainNew.DTO.Orders;
using WebStore.DomainNew.DTO.Products;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;
using WebStore.Interfaces.API;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Values
{

    public class OrdersClient : BaseClient, IOrdersService
    {
        public OrdersClient(IConfiguration config) : base(config, "api/orders") { }
        public IEnumerable<OrderDTO> GetUserOrders(string UserName) => Get<List<OrderDTO>>($"{_ServiceAddress}/user/{UserName}");

        public OrderDTO GetOrderById(int id) => Get<OrderDTO>($"{_ServiceAddress}/{id}");

        public OrderDTO CreateOrder(CreateOrderModel OrderModel, string UserName) =>
            Post($"{_ServiceAddress}/{UserName}", OrderModel)
               .Content
               .ReadAsAsync<OrderDTO>()
               .Result;
    }
}

