using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SuiteRx.Interface.Application;
using SuiteRx.Interface.Domain.Entities;
using SuiteRx.Interface.Persistance;
using SuiteRx.Interface.Persistance.Contexts;
using SuiteRx.Interface.Persistance.Seeders;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddRepositories(builder.Configuration);

builder.Services.AddDbContext<PharmacyDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<PharmacyDBContext>()
    .AddDefaultTokenProviders();

// JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


var app = builder.Build();

// Seed AspNetUsers
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PharmacyDBContext>();
    var users = AspNetUsersSeedData.GetUsers();
    var credentials = AspNetUsersSeedData.GetSeedCredentials();
    
    Console.WriteLine("\n========== SEEDING ASPNETUSERS ==========");
    
    foreach (var user in users)
    {
        var existingUser = context.Users.FirstOrDefault(u => u.Id == user.Id);
        
        if (existingUser == null)
        {
            context.Users.Add(user);
            Console.WriteLine($"✓ Added user: {user.UserName} ({user.Email})");
        }
        else
        {
            Console.WriteLine($"⚠ User already exists: {user.UserName}");
        }
    }
    
    try
    {
        context.SaveChanges();
        Console.WriteLine("✓ Database saved successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"✗ Error saving to database: {ex.Message}");
    }
    
    Console.WriteLine("\n========== SEED CREDENTIALS ==========");
    foreach (var (username, password, email) in credentials)
    {
        Console.WriteLine($"Username: {username}");
        Console.WriteLine($"Password: {password}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine("---");
    }
    Console.WriteLine("=====================================\n");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
