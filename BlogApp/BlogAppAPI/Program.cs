using BlogApp.Data.IRepos;
using BlogApp.Data.Repos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connection = builder.Configuration.GetConnectionString("BlogAppDBContext");
builder.Services.AddDbContext<BlogApp.Data.DBContext.BlogAppDBContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);
builder.Services.AddSingleton<IRoleRepo, RoleRepo>();
builder.Services.AddSingleton<IUserRepo, UserRepo>();
builder.Services.AddSingleton<IArticleRepo, ArticleRepo>();
builder.Services.AddSingleton<ICommentRepo, CommentRepo>();
builder.Services.AddSingleton<ITagRepo, TagRepo>();
builder.Services.AddAutoMapper(typeof(BlogAppAPI.Contracts.MappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
