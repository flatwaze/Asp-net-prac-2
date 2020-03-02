using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore.DomainNew.DTO.Products
{
    public class CategoryDTO : INamedEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}