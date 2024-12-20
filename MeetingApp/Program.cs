var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles(); // wwwroot u dışarıya açmış olduk
app.UseRouting();

// mvc
// rest api
//razor pages



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
