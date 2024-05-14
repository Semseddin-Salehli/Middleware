using Microsoft.EntityFrameworkCore;
using Middleware.Extension;
using Middleware.Models;
using NLog;
using NLog.Web;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

logger.Debug("init main");

builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContextPool<MiddlewareTaskContext>(opt => opt.UseSqlServer
       (builder.Configuration.GetConnectionString("MyConnection")));

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.Use((context, next) =>
{
    context.Request.EnableBuffering();
    return next();
});

app.UseControlMiddleware();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

NLog.LogManager.Shutdown();