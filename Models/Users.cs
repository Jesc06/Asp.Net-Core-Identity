
using Microsoft.AspNetCore.Identity;

namespace Asp.NetCore_Identity_Auth.Models
{
    public class Users : IdentityUser
    {
       public string Fullname { get; set; }
    }
}
