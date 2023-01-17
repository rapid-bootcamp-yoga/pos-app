using Microsoft.EntityFrameworkCore;
using POS.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//use SQL server
//var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
//builder.Services.AddDbContext<POS.Repository.ApplicationContext>(options => options.UseSqlServer(connectionString));

//var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");
//builder.Services.AddDbContext<POS.Repository.AppContext>(options => options.UseSqlServer(connectionString));

//use MySQL
var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");
builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    );

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
