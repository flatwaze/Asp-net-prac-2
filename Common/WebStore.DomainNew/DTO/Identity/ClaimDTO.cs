using System.Collections.Generic;
using System.Text;
using System.Security.Claims;

namespace WebStore.DomainNew.DTO.Identity
{
    public abstract class ClaimDTO : UserDTO
    {
        public IEnumerable<Claim> Claims { get; set; }
    }
}
