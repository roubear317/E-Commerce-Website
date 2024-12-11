using E_commerce.EF.Context;
using E_commerce.EF.Data.extentions;
using E_commerce.EF.Helpers;
using E_commerce.EF.Repos;
using E_Commerce.Core.Model;
using E_Commerce.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project_E_commerce.ExtentionService;
using Project_E_commerce.Middleware;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  
              .AllowAnyMethod()  
              .AllowAnyHeader(); 
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityService(builder.Configuration);


//builder.Services.AddSingleton<ConnectionMultiplexer>(c =>
//{
//    var configration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"),true);

//    return ConnectionMultiplexer.Connect(configration);
//});
//builder.Services.AddSingleton(builder.Configuration);
//builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

//builder.Services.AddScoped<UrlHelper>();

//builder.Services.AddAutoMapper(typeof(MapClassHelper));



builder.Services.AddAutoMapper(typeof(MapClassHelper));
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<UrlHelper>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IProductRepo,ProductRepo>();
//builder.Services.AddScoped<IBasketRepository,BasketRepository>();
builder.Services.AddScoped(typeof(IGenericRepo<>), (typeof(GenericRepo<>)));  
;var app = builder.Build();

using( var scope = app.Services.CreateScope())
{
    var scopeservice = scope.ServiceProvider;

    var LoggerFactory= scopeservice.GetRequiredService<ILoggerFactory>();

    try
    {
        var context = scopeservice.GetRequiredService<AppDbContext>();

       // var context = app.Services.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync();

        await SeedDataExtention.SeedDataAsync(context, LoggerFactory);

        var usermanager = scopeservice.GetRequiredService<UserManager<AppUser>>();

        var usercontext = scopeservice.GetRequiredService<AppDbContext>();

        await usercontext.Database.MigrateAsync();

        await SeedDataToUser.SeedDataUserAsync(usermanager);
    }
    catch(Exception ex)
    {
        var logger = LoggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An Error Occured during migration");
    }
}


// Configure the HTTP request pipeline.


app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseMiddleware<ExceptionsMiddleware>();


app.UseStatusCodePagesWithRedirects("/errors/{0}");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.MapControllers();

app.Run();
