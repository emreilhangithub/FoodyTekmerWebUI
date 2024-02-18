using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerBusinessLayer.Concrete;
using FoodyTekmerDataAccessLayer.Abstract;
using FoodyTekmerDataAccessLayer.Context;
using FoodyTekmerDataAccessLayer.EntityFremwork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductMenager>();
builder.Services.AddDbContext<FoodyContext>();

// Add services to the container.
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
    pattern: "{controller=default}/{action=Index}/{id?}");

app.Run();
