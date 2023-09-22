using Hospital.Repositonries;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Hospital.Utilites;
using Hospital.ViewModel;
using System.Data;
using Hospital.Repositonries.Interfaces;
using Hospital.Repositonries.Implemantations;
using Microsoft.AspNetCore.Identity.UI.Services;
using Hospital.Services;
using Hospital.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option=>
{ option.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection"), 
 sqlServerOptionsAction: sqlOptions =>
{
    sqlOptions.MigrationsAssembly("Hospital.Web");
});
});
builder.Services.AddIdentity<IdentityUser,IdentityRole>(/*options => options.SignIn.RequireConfirmedAccount = true*/)
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IDbIntiilizer,DbIntilizer>();
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IEmailSender,EmailSender>();
builder.Services.AddTransient<IHospitalServices,HospitalServices>();
builder.Services.AddTransient<IRoomServices,RoomServices>();
builder.Services.AddTransient<IContactServiceses,Contactservices>();
builder.Services.AddTransient<IAppllecationUserServices, ApleacationUserServices>();
builder.Services.AddRazorPages();


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
DataSeed();
app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{Area=admin}/{controller=Hospital}/{action=Index}/{id?}");

app.Run();
void DataSeed()
{
   using (var scope =app.Services.CreateScope())
    {
        var dbIninitilezer = scope.ServiceProvider.GetRequiredService<IDbIntiilizer>();
        dbIninitilezer.Intiilizer();
    }
}