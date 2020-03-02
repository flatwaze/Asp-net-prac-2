using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore.DomainNew.DTO.Products
{
    public class BrandDTO : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}