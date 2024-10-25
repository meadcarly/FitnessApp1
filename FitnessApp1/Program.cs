using System.Data;
using FitnessApp1;
using FitnessApp1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserDb>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("FitnessAppDatabase"), new MySqlServerVersion(new Version(8, 0, 33))));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection conn = new MySqlConnection(builder.Configuration.GetConnectionString("FitnessAppDatabase"));
    conn.Open();
    return conn;
});

builder.Services.AddTransient<IExerciseRepo, ExerciseRepo>();

builder.Services.AddTransient<IMeasurementRepo, MeasurementRepo>();

builder.Services.AddTransient<IGoalsRepo, GoalRepo>();

var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapRazorPages();

app.Run();