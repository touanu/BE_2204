using Microsoft.EntityFrameworkCore;
using StudentManager.DataAccess.DBContext;
using StudentManager.DataAccess.IServices;
using StudentManager.DataAccess.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StudentDBContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("ConnStr")));

builder.Services.AddTransient<IStudentServices, StudentServices>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
