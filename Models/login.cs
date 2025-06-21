
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Asp.NetCore_Identity_Auth.Models
{
    public class login : IdentityUser
    {
       public string fullname { get; set; }
    }
}
