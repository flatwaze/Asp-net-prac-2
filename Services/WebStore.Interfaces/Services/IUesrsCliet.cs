using Microsoft.AspNetCore.Identity;
using WebStore.DomainNew.Entities;

namespace WebStore.Interfaces.Services
{
    public interface IUesrsCliet :
        IUserRoleStore<User>,
        IUserPasswordStore<User>,
        IUserEmailStore<User>,
        IUserPhoneNumberStore<User>,
        IUserTwoFactorStore<User>,
        IUserLockoutStore<User>,
        IUserClaimStore<User>,
        IUserLoginStore<User>
    { }
}
