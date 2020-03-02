using System.Security.Claims;

namespace WebStore.DomainNew.DTO.Identity
{
    public class ReplaceClaim : UserDTO
    {
        public Claim Claim { get; set; }
        public Claim NewClaim { get; set; }

    }
}
