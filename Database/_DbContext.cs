using Asp.NetCore_Identity_Auth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Asp.NetCore_Identity_Auth.Database
{
    public class _DbContext : IdentityDbContext<Users>
    {
        public _DbContext(DbContextOptions options) : base(options) { }
    }
}
