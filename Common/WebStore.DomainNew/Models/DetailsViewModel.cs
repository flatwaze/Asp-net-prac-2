using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Models;

namespace WebStore.DomainNew.Models
{
    class DetailsViewModel
    {
        public CartViewModel CartViewModel { get; set; }
        public OrderViewModel OrderViewModel { get; set; }
    }
}
