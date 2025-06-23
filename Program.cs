using Asp.NetCore_Identity_Auth.Database;
using Asp.NetCore_Identity_Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

//for MVC registration
builder.Services.AddControllersWithViews();

//for DbContext Configuration
builder.Services.AddDbContext<_DbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("database")));

//Setup for Identity Auth configuration
builder.Services.AddIdentity<Users, IdentityRole>(option =>
{
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequiredLength = 3;

    option.User.RequireUniqueEmail = true; 
    option.SignIn.RequireConfirmedEmail = false;

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
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name:"default",
    pattern: "{controller=Account}/{action=login}/{id?}"
);


app.Run();
