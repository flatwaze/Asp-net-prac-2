using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.DTO.Orders;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersApiController : ControllerBase, IOrdersService
    {
        public readonly IOrdersService _OrdersService;
        public OrdersApiController(IOrdersService OrdersService) => _OrdersService = OrdersService;

        [HttpPost("{UserName?}")]
        public OrderDTO CreateOrder(CreateOrderModel orderModel, string userName) => _OrdersService.CreateOrder(orderModel, userName);

        [HttpGet("{id}"), ActionName("Get")]
        public OrderDTO GetOrderById(int id) => _OrdersService.GetOrderById(id);

        [HttpGet("user/{userNae}")]
        public IEnumerable<OrderDTO> GetUserOrders(string userName) => _OrdersService.GetUserOrders(userName);
    }
}