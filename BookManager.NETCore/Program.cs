using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookManager.NETCore.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookManagerNETCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookManagerNETCoreContext") ?? throw new InvalidOperationException("Connection string 'BookManagerNETCoreContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
