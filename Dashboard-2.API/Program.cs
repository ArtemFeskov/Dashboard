using Dashboard.Data.Data.Classes;
using Dashboard.Data.Data.Context;
using Dashboard.Data.Data.Interfaces;
using Dashboard.Data.Data.Models;
using Dashboard.Data.Initializer;
using Dashboard.Servises;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>();

// Add User Service
builder.Services.AddTransient<UserService>();

// Add User Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add and configurate identity user and roles
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.User.RequireUniqueEmail = true;


})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();




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

await AppDbInitialaser.Seed(app);
app.Run();