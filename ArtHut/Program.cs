using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ArtHut.Data;
using ArtHut.Data.Models;
using ArtHut.Controllers;
using Microsoft.AspNetCore.Identity.UI.Services;
using ArtHut.Data.Repositories.Interfaces;
using ArtHut.Business.Services.Interfaces;
using ArtHut.Data.Repositories;
using ArtHut.Business.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ArtHutDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ArtHutDbContext>();

builder.Services.AddRazorPages();

builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

builder.Services.AddScoped<IPhotosRepository, PhotosRepository>();
builder.Services.AddScoped<IPhotosService, PhotosService>();

builder.Services.AddScoped<IMessagesRepository, MessagesRepository>();
builder.Services.AddScoped<IMessagesService, MessagesService>();

builder.Services.AddScoped<ICartItemsRepository, CartItemsRepository>();
builder.Services.AddScoped<ICartsService, CartsService>();

builder.Services.AddScoped<IAddressesRepository, AddressesRepository>();
builder.Services.AddScoped<IAddressesService, AddressesService>();

builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<ICountriesService, CountriesService>();

builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IPaymentsRepository, PaymentsRepository>();
builder.Services.AddScoped<IPaymentsService, PaymentsService>();

var app = builder.Build(); 

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.UseCors(c => c
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

app.Run();

