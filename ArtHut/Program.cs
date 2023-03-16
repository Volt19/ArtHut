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

//builder.Services.AddIdentityServer()
//    .AddApiAuthorization<User, ArtHutDbContext>();

//builder.Services.AddAuthentication()
//    .AddIdentityServerJwt();
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ITagsRepository, TagsRepository>();
builder.Services.AddScoped<ITagsService, TagsService>();

builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

builder.Services.AddScoped<IPhotosRepository, PhotosRepository>();
builder.Services.AddScoped<IPhotosService, PhotosService>();

builder.Services.AddScoped<IMessagesRepository, MessagesRepository>();
builder.Services.AddScoped<IMessagesService, MessagesService>();

builder.Services.AddScoped<ICartsRepository, CartsRepository>();
builder.Services.AddScoped<ICartItemsRepository, CartItemsRepository>();
builder.Services.AddScoped<ICartsService, CartsService>();

var app = builder.Build(); 

// Configure the HTTP request pipeline.
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
