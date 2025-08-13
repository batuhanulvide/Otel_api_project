using FluentValidation;
using FluentValidation.AspNetCore;
using HotelApiProject.DataAccessLayer.Concrete;
using HotelApiProject.EntityLayer.Concrete;
using HotelApiProject.WebUI.Dtos.GuestDtos;
using HotelApiProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//** FLUENT VALIDATON **
//Burada validation .net 6.0 a uygun bir yöntemle dahil ediliyor.
builder.Services.AddFluentValidationAutoValidation(); 
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
//*** FLUENT VALIDATON **

builder.Services.AddControllersWithViews(); //FluentValidation ekleniyor
builder.Services.AddHttpClient();//Client Cors için dependency injection
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();

//Proje seviyesinde Authorization uyguluyoruz.
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/Login/Index";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10); //Authentication olan kullanýcý ne kadar sürede çýkýþ yaptýrsýn.
    options.LogoutPath = "/Login/LogOut";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//404 Hatasý için
app.UseStatusCodePagesWithReExecute("/Default/error404", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
