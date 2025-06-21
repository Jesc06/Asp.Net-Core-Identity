using Asp.NetCore_Identity_Auth.Database;
using Asp.NetCore_Identity_Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<_DbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("database")));


builder.Services.AddIdentity<login, IdentityRole>(option =>
{
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequiredLength = 8;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;
    option.User.RequireUniqueEmail = true;
    option.SignIn.RequireConfirmedAccount = false;
    option.SignIn.RequireConfirmedEmail = false;
    option.SignIn.RequireConfirmedPhoneNumber = false;
})
    .AddEntityFrameworkStores<_DbContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
);

app.Run();
