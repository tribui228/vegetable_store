using Microsoft.EntityFrameworkCore;
using NToastNotify;
using Microsoft.AspNetCore.Identity;
using Web_market.Models;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(p =>
                {
                    p.Cookie.Name = "UserLoginCookie";
                    p.ExpireTimeSpan = TimeSpan.FromMinutes(1);
                    p.LoginPath = "/dang-nhap.html";
                    p.LogoutPath = "/dang-xuat/html";
                    p.AccessDeniedPath = "/";
                });
builder.Services.AddSingleton<HtmlEncoder>(

     HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

builder.Services.AddDbContext<DbMarketsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbMarkets")));

builder.Services.AddSession();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
// Add ToastNotification services

builder.Services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
{

   
    ProgressBar = true,
    Timeout = 5000
});


// Use ToastNotification middleware


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseNToastNotify();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
