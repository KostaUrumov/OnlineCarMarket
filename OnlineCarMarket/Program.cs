using Microsoft.EntityFrameworkCore;
using OnlineCarMarket_Infastructure.Data;
using OnlineCarMarket_Infastructure.Entities;
using OnlineCarMarket_Core.Interfaces;
using OnlineCarMarket_Core.Services.CarServ;
using OnlineCarMarket_Core.Services.UserServ;
using Microsoft.AspNetCore.Identity;
using OnlineCarMarket_Core.Services.EngServ;
using OnlineCarMarket_Core.Services.ContServ;
using OnlineCarMarket_Core.Services.BodyServ;
using OnlineCarMarket_Core.Services.ManServ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>
    (options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 5;
        options.Password.RequireDigit = false;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.Password.RequireUppercase = false;
        options.User.RequireUniqueEmail = true;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ICarService, CarServices>();
builder.Services.AddScoped<IEngine, EngineServices>();
builder.Services.AddScoped<ICountry, CountryServices>();
builder.Services.AddScoped<IBody, BodyTypeServices>();
builder.Services.AddScoped<IManifacturer, ManifacturerServices> ();



builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminsOnly", policy => policy.RequireRole("Admin"));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UsersOnly", policy => policy.RequireRole("User"));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
