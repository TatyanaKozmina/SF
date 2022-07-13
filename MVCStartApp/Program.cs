using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(connection));
// регистрация сервиса репозитория для взаимодействия с базой данных
builder.Services.AddTransient<IBlogRepository, BlogRepository>();
builder.Services.AddTransient<IHistoryRepository, HistoryRepository>();

builder.Services.AddControllersWithViews();

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

// Подключаем логирование с использованием ПО промежуточного слоя
app.UseMiddleware<MVCStartApp.Middlewares.LoggingMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
