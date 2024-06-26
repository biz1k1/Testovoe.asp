using Application;
using Infrastructure;
using Web;
using Web.Infrastracture;
using Web.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddWebServices();
builder.Services.AddControllersWithViews(option =>
{
    option.ModelBinderProviders.Insert(0, new CustomModelBinderProvider());
});
builder.Services
    .AddInfrastructureServices(builder.Configuration)
    .AddApplicationServices();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
