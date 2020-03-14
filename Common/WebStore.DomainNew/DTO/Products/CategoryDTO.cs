using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore.DomainNew.DTO.Products
{
    public class CategoryDTO : INamedEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public int Order { get; set; }
    }
}