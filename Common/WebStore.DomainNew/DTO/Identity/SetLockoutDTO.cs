using System;

namespace WebStore.DomainNew.DTO.Identity
{
    public class SetLockoutDTO : UserDTO {
        public DateTimeOffset? LockoutEnd { get; set; }
    }
}
