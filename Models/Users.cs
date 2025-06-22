
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Asp.NetCore_Identity_Auth.Models
{
    public class Users : IdentityUser
    {
       public string Fullname { get; set; }
    }
}
