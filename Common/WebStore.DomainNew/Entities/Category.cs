using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.DomainNew.Entities.Base;
using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore.DomainNew.Entities
{
    [Table("Categories")]
    public class Category : NamedEntity, IOrderedEntity
    {
        public int? ParentId { get; set; }

        public int Order { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}