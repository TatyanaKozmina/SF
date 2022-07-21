using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolJournal.Data;
using SchoolJournal.Data.Repos;


var builder = WebApplication.CreateBuilder(args);


string connection = builder.Configuration.GetConnectionString("SchoolJournalDBContext");
builder.Services.AddDbContext<SchoolJournalDBContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);
builder.Services.AddSingleton<IStreamRepository, StreamRepository>();


//builder.Services.AddDbContext<SchoolJournalContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolJournalContext") ?? throw new InvalidOperationException("Connection string 'SchoolJournalContext' not found.")));

// Add services to the container.
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
