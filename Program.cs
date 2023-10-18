// WebApplication
var builder = WebApplication.CreateBuilder(args);

// middlewares (adiciono)
builder.Services.AddControllersWithViews();

//
builder.Services.AddTransient<IStatusData, StatusSql>();
builder.Services.AddSingleton<ITaskData, TaskData>();

var app = builder.Build();

// middlewares (configuro)
app.MapControllerRoute("default", "/{controller=Status}/{action=Index}/{id?}");


app.Run();





















// http://localhost:1234/[CLASS]/[METHOD]

// http://localhost:1234/[Controller]/[Action]

// class Produto {
// string get() {} 
// }

// http://localhost:1234/Produto/get -> String