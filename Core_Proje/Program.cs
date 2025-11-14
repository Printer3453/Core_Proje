using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);


// DbContext (Context) kaydý
// Context içinde zaten OnConfiguring(UseSqlServer(...)) yazdýðýn için
// burada connection string vermesen de çalýþýr, ama istersen þöyle de yapabilirsin:
// builder.Services.AddDbContext<Context>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<Context>();


// IDENTITY kaydý - EN ÖNEMLÝ KISIM
builder.Services.AddIdentity<WriteUser, WriterRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

// MVC
builder.Services.AddControllersWithViews();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios,
    // see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Areas route
app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
    );

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

 

app.Run();



