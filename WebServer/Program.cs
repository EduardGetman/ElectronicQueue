using ElectronicQueue.WebServer.Interfaces;
using ElectronicQueue.WebServer.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IQueuesService, QueuesService>();

var app = builder.Build();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();