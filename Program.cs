
using ChushkaAssignment.Data;
using ChushkaAssignment.Data.Enums;
using ChushkaAssignment.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    //Password settings
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    string fullName = "Admin";
    string email = "admin@admin.com";
    string password = "A123456a!";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new AppUser
        {
            FullName = fullName,
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }
    fullName = "Pesho";
    email = "pesho@peshov.com";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new AppUser
        {
            FullName = fullName,
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "User");
    }
}
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
    string name = "Chuskopek";
    decimal price = 500m;
    string description = "A universal tool for peking chushkas.";
    var type = ProductType.Domestic;

    if (!dbContext!.Products.Any())
    {
        for (int i = 0; i < 5; i++)
        {
            var product = new Product
            {
                Name = name,
                Price = price,
                Description = description,
                Type = type,
            };
            dbContext.Products.Add(product);
        }
        name = "Injektoplqktor";
        price = 1.56m;
        description = "A universal tool for basically everything. It's banana.";
        type = ProductType.Others;
        for (int i = 0; i < 5; i++)
        {
            var product2 = new Product
            {
                Name = name,
                Price = price,
                Description = description,
                Type = type,
            };
            dbContext.Products.Add(product2);
        }
        dbContext.SaveChanges();
    }
}

app.Run();
