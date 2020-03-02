using Microsoft.AspNetCore.Identity;
using WebStore.DomainNew.Entities;

namespace WebStore.Interfaces.Services
{
    public interface IRolesClient : IRoleStore<Role> { }
}
