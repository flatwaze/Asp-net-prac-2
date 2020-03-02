using Microsoft.AspNetCore.Identity;

namespace WebStore.DomainNew.DTO.Identity
{
    public class AddLoginDTO : UserDTO {
        public UserLoginInfo UserLoginInfo { get; set; }
    }
}
