using System;
using Microsoft.AspNetCore.Identity;

namespace WebStore.DomainNew.Entities
{
    public class Role : IdentityRole
    {
        public string User = "User";
        public string Admin = "Admin";

        public string Description { get; set; }
    }
}
