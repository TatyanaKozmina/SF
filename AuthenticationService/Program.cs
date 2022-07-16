using AuthenticationService;
using AuthenticationService.Middlewares;
using AuthenticationService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<AuthenticationService.Middlewares.ILogger, Logger>();

var mapperConfig = new AutoMapper.MapperConfiguration(v => { v.AddProfile(new MappingProfile()); });
AutoMapper.IMapper mapper = new AutoMapper.Mapper(mapperConfig);
builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options => options.DefaultScheme = "Cookies")
    .AddCookie("Cookies", options =>
    {
        options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
        {
            OnRedirectToLogin = redirectContext =>
            {
                redirectContext.HttpContext.Response.StatusCode = 401;
                return Task.CompletedTask;
            }
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseLogMiddleware();

app.MapControllers();

app.Run();
