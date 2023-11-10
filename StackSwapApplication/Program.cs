using Microsoft.EntityFrameworkCore;
using StackSwapApplication.Data;
using StackSwapApplication.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StackSwappDB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;  MultipleActiveResultSets=True";

builder.Services.AddDbContext<TradeContext>(options =>
{
options.UseSqlServer(builder.Configuration.GetConnectionString("StackSwappContext") ?? connectionString);
});

builder.Services.AddTransient<IDataService, DataRepository>();

builder.Services.AddScoped<ICatalogueService, CatalogueRepository>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
