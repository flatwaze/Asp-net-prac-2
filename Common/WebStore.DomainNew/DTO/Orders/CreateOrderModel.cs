using System.Collections.Generic;
using System.Text;
using WebStore.Models;

namespace WebStore.DomainNew.DTO.Orders
{
    public class CreateOrderModel
    {
        public OrderViewModel OrderViewModel { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }

    }

}
