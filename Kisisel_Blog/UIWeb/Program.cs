using Business.Containers;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using UIWeb.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc().AddFluentValidation();
builder.Services.MyServiceInstance();

builder.Services.AddAuthentication("Cookies").AddCookie(x =>
{
    x.LoginPath = "/admin/Giris";// Giriş yapılan sayfalara grirldiğinde yönlendirilecek olan sayfa
    x.LogoutPath = "/admin/Cikis";//Çıkış yapılmasını sağlayan sayfa
    x.AccessDeniedPath = "/admin/Giris"; // YEtkissiz Giril Yapıldığı zaman Yönlendirilecek sayfa

});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(x =>
{
    x.MapDefaultControllerRoute();
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Giris}/{action=Index}/{id?}"
    );
});

app.Run();
