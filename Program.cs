using Microsoft.EntityFrameworkCore;
using PokemonFinder.Models;
using PokemonFinder.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PokemonContext>(options =>
{
    options.UseSqlServer
    (builder.Configuration.GetConnectionString
    ("Database"));
    options.EnableDetailedErrors();
});
builder.Services.AddTransient<PokemonAPIService>();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".PokemonApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient<PokemonAPIService>();
builder.Services.AddScoped<PokemonAPIService>();
builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<PokemonService>();
// Add services to the container.
builder.Services.AddRazorPages();

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

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();


