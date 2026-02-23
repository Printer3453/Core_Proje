using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Core_Proje.AiPlugins;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.SemanticKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);


// DbContext (Context) kaydý
// Context içinde zaten OnConfiguring(UseSqlServer(...)) yazdýðýn için
// burada connection string vermesen de çalýþýr, ama istersen þöyle de yapabilirsin:
// builder.Services.AddDbContext<Context>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<PortfolioInfoPlugin>();

builder.Services.AddKernel();
builder.Services.AddScoped<IPortfolioDal, EfPortfolioDal>();
builder.Services.AddScoped<IPortfolioService, PortfolioManager>();
builder.Services.AddTransient<Kernel>(sp =>
{
    // Plugin'i DI konteynerinden çek (Böylece Business Manager da dolu gelir)
    var plugin = sp.GetRequiredService<PortfolioInfoPlugin>();

    var kBuilder = Kernel.CreateBuilder();

    // Plugin'i Kernel'a ekle
    kBuilder.Plugins.AddFromObject(plugin, "Portfolio");
    string apiKey = "Buraya kendi key inizi giriniz";
    
    kBuilder.AddOpenAIChatCompletion(

        modelId: "gpt-4o-mini",
        apiKey: apiKey
    );

    return kBuilder.Build();
});

// IDENTITY kaydý - EN ÖNEMLÝ KISIM
builder.Services.AddIdentity<WriterUser, WriterRole>()
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



