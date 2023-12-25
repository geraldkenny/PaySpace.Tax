using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using PaySpace.Tax.Application.Services;
using PaySpace.Tax.Application.Services.Interfaces;
using PaySpace.Tax.Infrastructure.Data;
using PaySpace.Tax.Infrastructure.Repositories;
using PaySpace.Tax.Infrastructure.Repositories.Interfaces;
using PaySpace.Tax.Web.Controllers.Handlers;
using PaySpace.Tax.Web.Controllers.Handlers.Interfaces;
using PaySpace.Tax.Web.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPostalCodeRepository, PostalCodeRepository>();
builder.Services.AddScoped<UserInputValidator>();
builder.Services.AddSingleton<ITaxCalculationServiceFactory, TaxCalculationServiceFactory>();
builder.Services.AddScoped<ITaxControllerHandler, TaxControllerHandler>();
builder.Services.AddScoped<ITaxCalculationResultRepository, TaxCalculationResultRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    // Improve security and guards against DDoS attacks, Reduces unnecessary resource usage
    rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    rateLimiterOptions.AddConcurrencyLimiter("concurrency", options =>
    {
        options.PermitLimit = 1000;
        options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 900;
    });
});

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

app.UseRateLimiter();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
