var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute("default","/{controller=status}/{action=Index}/{id?}");
app.Run();
