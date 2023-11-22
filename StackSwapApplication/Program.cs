using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using StackSwapApplication.Data;
using StackSwapApplication.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TradeContext>(options => options.UseSqlite(connectionString));

builder.Services.AddScoped<IDataService, DataRepository>();

builder.Services.AddScoped<ICatalogueService, CatalogueRepository>();

builder.Services.AddScoped<IPurchaseTransactionService, PurchaseTransactionRespository>();

builder.Services.AddScoped<ICardService, CardRepository>(); 

builder.Services.AddScoped<IUserAuthenticationService, AuthenticationRepository>();

builder.Services.AddScoped<IUserSession, UserSessionRepo>();

builder.Services.AddScoped<ITradeService, TradeManager>();


builder.Services.AddHttpContextAccessor(); 

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
  //  options.Cookie.HttpOnly = true;
    //options.Cookie.IsEssential = true;
});

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

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
	pattern: "{controller=Home}/{action=MainPage}/{id?}");
//pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
