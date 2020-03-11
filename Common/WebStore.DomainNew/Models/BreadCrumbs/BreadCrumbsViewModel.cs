namespace WebStore.DomainNew.Models.BreadCrumbs
{
    public enum BreadCrumbsType : byte
    {
        None,
        Category,
        Brand,
        Product
    }

    public class BreadCrumbsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public BreadCrumbsType BreadCrumbsType { get; set; }
    }
}