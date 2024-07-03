using DapperProject.Context;
using DapperProject.Services;
using DapperProject.Services.AdvertServices;
using DapperProject.Services.AgentServices;
using DapperProject.Services.CategoryServices;
using DapperProject.Services.LocationServices;
using DapperProject.Services.TagServices;
using DapperProject.Services.TestimonialServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<DapperContext>();

builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IAdvertService, AdvertService>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<ITagService, TagService>();

builder.Services.AddControllersWithViews();

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
