
using Microsoft.AspNetCore.Identity;
using StoreOfBuild.Domain.Account;

namespace StoreOfBuild.Data
{
    public class ApplicationUser : IdentityUser, IUser
    {
            // IdentityUser ja contem as mesmas propriedades de IUser ela não precisa ser implementada 
    }
}