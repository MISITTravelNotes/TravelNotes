using Lab0225_InitProject.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TravelContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TravelContext")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AiRecommend}/{action=Index}/{id?}");

app.Run();
